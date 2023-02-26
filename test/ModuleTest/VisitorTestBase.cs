using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Coding4fun.TransactSql.Validations;
using Coding4fun.TransactSql.Validations.Extensions;
using Coding4fun.TransactSql.Validations.Visitors;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Xunit;

namespace Coding4fun.TransactSql.ModuleTest
{
    /// <summary>
    ///     Базовый класс для тетсирования visitor.
    /// </summary>
    public abstract class VisitorTestBase<TVisitor>
        where TVisitor : SqlVisitorBase, new()
    {
        /// <summary>
        ///     Инструмент для тестов visitor.
        /// </summary>
        protected class TestBuilder
        {
            private const string TestData = @".\TestData";
            private readonly string _testFilePath;
            private readonly TVisitor _visitor;

            /// <summary>
            ///     Инициализация пути к файлу с тестом.
            /// </summary>
            /// <param name="methodName">Если null, то название файла совпадет с названием вызывающего метода.</param>
            public TestBuilder([CallerMemberName] string methodName = null)
            {
                _testFilePath = Path.Combine(TestData, typeof(TVisitor).Name, methodName + ".sql");
                _visitor = new TVisitor();
            }

            /// <summary>
            ///     Инициализация visitor.
            /// </summary>
            /// <param name="initialization">Инициализация.</param>
            public TestBuilder Initialize(Action<TVisitor> initialization)
            {
                initialization.Invoke(_visitor);
                return this;
            }

            /// <summary>
            ///     Проверка кода на отсутствие ошибок в visitor.
            /// </summary>
            public void AssertDoesNotHaveErrors() => Validate(visitor => Assert.Empty(visitor.ValidationResults));

            /// <summary>
            ///     Проверка кода на присутствие ошибки в visitor.
            /// </summary>
            /// <param name="resultCode">Ожидаемой код ошибки, вернувшийся из TValidator.</param>
            /// <param name="identifier">Идентификатор, в котором имеется ошибка.</param>
            public void AssertHasError(int resultCode, string identifier)
            {
                AssertHasErrors(new[]
                {
                    new StringValidationResult(resultCode, identifier)
                });
            }

            /// <summary>
            ///     Проверка кода на присутствие ошибок visitor.
            /// </summary>
            /// <param name="expectedValidationResults"></param>
            private void AssertHasErrors(StringValidationResult[] expectedValidationResults)
            {
                Validate(validation =>
                {
                    Assert.Equal(
                        expectedValidationResults,
                        validation.ValidationResults.Select(StringValidationResult.Convert).ToArray(),
                        StringValidationResultEqualityComparer.Instance);
                });
            }

            /// <summary>
            ///     Валидация кода Transact SQL.
            /// </summary>
            /// <param name="assertAction">Ожидания от проверок.</param>
            private void Validate(Action<TVisitor> assertAction)
            {
                using (var sqlFileStream = File.OpenRead(_testFilePath))
                using (TextReader sqlTextReader = new StreamReader(sqlFileStream))
                {
                    var parser = new TSql150Parser(true, SqlEngineType.All);
                    var tree = parser.Parse(sqlTextReader, out var errors);
                    if (errors.Any()) throw new InvalidOperationException($"SQL has errors in file: {_testFilePath}");
                    tree.Accept(_visitor);
                }

                assertAction.Invoke(_visitor);
            }
        }

        /// <summary>
        ///     Результат проверки кода.
        /// </summary>
        protected class StringValidationResult
        {
            public StringValidationResult(int errorCode, string identifier)
            {
                ErrorCode = errorCode;
                Identifier = identifier;
            }

            /// <summary>
            ///     Ожидаемый код ошибки.
            /// </summary>
            public int ErrorCode { get; }

            /// <summary>
            ///     Текстовый идентификатор, над которым произошла ошибка.
            /// </summary>
            public string Identifier { get; }

            /// <summary>
            ///     Преобразование результата валидации в пригодный для теста вид.
            /// </summary>
            public static StringValidationResult Convert(ValidationResult validationResult)
            {
                string invalidElementText;

                switch (validationResult.InvalidObject)
                {
                    case Identifier identifier:
                        invalidElementText = identifier.Value;
                        break;
                    case NamedTableReference reference:
                        invalidElementText = reference.SchemaObject.BaseIdentifier.Value;
                        break;
                    case StringLiteral stringLiteral:
                        invalidElementText = stringLiteral.Value;
                        break;
                    default:
                    {
                        var textElements = validationResult.InvalidObject.ScriptTokenStream
                            .Skip(validationResult.InvalidObject.FirstTokenIndex)
                            .Take(validationResult.InvalidObject.Let(o => o.LastTokenIndex - o.FirstTokenIndex + 1))
                            .Select(token => token.Text)
                            .ToArray();

                        invalidElementText = string.Join("", textElements);
                        break;
                    }
                }

                return new StringValidationResult(validationResult.ResultCode, invalidElementText);
            }
        }

        private class StringValidationResultEqualityComparer : IEqualityComparer<StringValidationResult>
        {
            public static readonly StringValidationResultEqualityComparer
                Instance = new StringValidationResultEqualityComparer();

            [ExcludeFromCodeCoverage]
            public bool Equals(StringValidationResult x, StringValidationResult y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.ErrorCode == y.ErrorCode && string.Equals(x.Identifier, y.Identifier,
                    StringComparison.InvariantCultureIgnoreCase);
            }

            [ExcludeFromCodeCoverage]
            public int GetHashCode(StringValidationResult obj)
            {
                unchecked
                {
                    return (obj.ErrorCode * 397) ^ (obj.Identifier != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Identifier)
                        : 0);
                }
            }
        }
    }
}