using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Coding4fun.TransactSql.Validations.Extensions;
using JetBrains.Annotations;
using Xunit;

namespace Coding4fun.TransactSql.IntegrationTest
{
    /// <summary>
    ///     Тестирование правил посредством файла с результатом анализа проекта ExampleSqlProject.
    /// </summary>
    public class RuleTests
    {
        /// <summary>
        ///     Копирование файла объявлено в `PostBuild` в IntegrationTest.csproj.
        /// </summary>
        private const string CodeAnalysisResult = @".\ExampleSqlProject.StaticCodeAnalysis.Results.xml";

        /// <summary>
        ///     Список ожидаемых ошибок.
        ///     Задается путем копирования из ExampleSqlProject.StaticCodeAnalysis.Results.xml после визуального осмотра в VS.
        /// </summary>
        private const string ExpectedProblemsXmlPath = @".\ExpectedProblems.xml";

        private static readonly Regex Last4Parts =
            new Regex(@"(?<=<SourceFile>)(.+?\\)(?=([^\\]+\\){3}[^\\]+</SourceFile>)",
                RegexOptions.RightToLeft | RegexOptions.Compiled);

        [Fact]
        public void Test()
        {
            var actualProblems = ReadRawProblems(CodeAnalysisResult);
            var expectedProblems = new StreamReader(ExpectedProblemsXmlPath).Using(DeserializeProblems);
            Assert.True(expectedProblems.SetEquals(actualProblems));
        }

        /// <summary>
        ///     Чтение файла с результатом анализа кода.
        ///     На выходе полный путь к исходному файлу заменяется на его последние 4 части.
        /// </summary>
        /// <param name="problemsPath">Путь к файлу с результатом анализа кода.</param>
        /// <returns>Множество проблем, выявленных при анализе кода.</returns>
        private static HashSet<Problem> ReadRawProblems(string problemsPath)
        {
            var prettyXmlStringBuilder = new StringBuilder();
            foreach (var lineFromCodeAnalysis in File.ReadLines(problemsPath))
            {
                var prettyLine = KeepOnlyLast4Parts(lineFromCodeAnalysis);
                prettyXmlStringBuilder.AppendLine(prettyLine);
            }

            var xml = prettyXmlStringBuilder.ToString();
            return new StringReader(xml).Using(DeserializeProblems);
        }

        /// <summary>
        ///     Десериализация проблем анализа кода.
        /// </summary>
        /// <param name="problemsTextReader">Xml</param>
        /// <returns>Множество проблем, выявленных при анализе кода.</returns>
        private static HashSet<Problem> DeserializeProblems(TextReader problemsTextReader)
        {
            using (var xmlReader = XmlReader.Create(problemsTextReader))
            {
                var problems = (Problems)new XmlSerializer(typeof(Problems)).Deserialize(xmlReader);
                return new HashSet<Problem>(problems);
            }
        }

        private static string KeepOnlyLast4Parts(string line)
        {
            // Замена: <SourceFile>C:\Users\user_name\Documents\Sources\TransactSqlValidation\test\ExampleSqlProject\dbo\Tables\TableWithInvalidНейм.sql</SourceFile>
            // На 4 справа части: <SourceFile>ExampleSqlProject\dbo\Tables\TableWithInvalidНейм.sql</SourceFile>
            return Last4Parts.Replace(line, match => match.Groups["trash"].Value);
        }

        /// <summary>
        ///     Список ошибок, выявленных при анализе кода (необходим для десериализации).
        /// </summary>
        [UsedImplicitly]
        [XmlType("Problems")]
        public class Problems : List<Problem>
        {
        }

        /// <summary>
        ///     Ошибка, выявленная при анализе кода.
        /// </summary>
        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        public sealed class Problem
        {
            /// <summary>
            ///     Номер правила.
            /// </summary>
            /// <example>Coding4fun.SR1002</example>
            public string Rule { get; set; }

            /// <summary>
            ///     Описание проблемы.
            /// </summary>
            /// <example>Object name has to include [schema_name] and [object_name], but was: MY_TABLE</example>
            public string ProblemDescription { get; set; }

            /// <summary>
            ///     Полный путь к файлу с исходным кодом (в нашем случае остается только последние его 4 части).
            /// </summary>
            /// <example>ExampleSqlProject\dbo\Stored Procedures\InvalidIdentifierPath.sql</example>
            public string SourceFile { get; set; }

            /// <summary>
            ///     Номер строки исходного кода, в которой обнаружилась ошибка.
            /// </summary>
            public string Line { get; set; }

            /// <summary>
            ///     Смещение внутри строки.
            /// </summary>
            public string Column { get; set; }

            /// <summary>
            ///     Уровень критичности: Warning/Error.
            ///     Зависит от настроек sqlproj в разделе `SqlCodeAnalysisRules`:
            ///     если в `-!Coding4fun.SR1003` минус заменить на плюс, то Warning будет заменен на Error во время формирования отчета
            ///     анализа кода.
            /// </summary>
            public string Severity { get; set; }

            /// <inheritdoc />
            public override string ToString() => $"[{Rule}] {ProblemDescription} | {SourceFile}";

            private bool Equals(Problem other) => Rule == other.Rule &&
                                                  ProblemDescription == other.ProblemDescription &&
                                                  SourceFile == other.SourceFile && Line == other.Line &&
                                                  Column == other.Column && Severity == other.Severity;

            /// <inheritdoc />
            public override bool Equals(object obj) =>
                ReferenceEquals(this, obj) || (obj is Problem other && Equals(other));

            /// <inheritdoc />
            [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = Rule != null ? Rule.GetHashCode() : 0;
                    hashCode = (hashCode * 397) ^ (ProblemDescription != null ? ProblemDescription.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (SourceFile != null ? SourceFile.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Line != null ? Line.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Column != null ? Column.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Severity != null ? Severity.GetHashCode() : 0);
                    return hashCode;
                }
            }

            public static bool operator ==(Problem left, Problem right) => Equals(left, right);

            public static bool operator !=(Problem left, Problem right) => !Equals(left, right);
        }
    }
}