using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Coding4fun.TransactSql.Validations.BuildContributors;
using Coding4fun.TransactSql.Validations.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.Validations.Rules
{
    /// <summary>
    ///     Проверка строковых значений на невалидные значения (предположим, сочетание кириллицы и латиницы в одном слове)
    ///     Для чтения иссключений из коментариев необходимо включить в sqlproj:
    ///     <code>&lt;IgnoreComments&gt;False&lt;/IgnoreComments&gt;</code>
    /// </summary>
    [LocalizedExportCodeAnalysisRule(RuleCodes.Rule001,
        nameof(RuleResources.StringLiteral_RuleName),
        Category = RuleCategories.Naming,
        RuleScope = SqlRuleScope.Element)]
    public class StringLiteralRule : SqlCodeAnalysisRuleBase<StringLiteralVisitor>
    {
        /// <summary>
        ///     Подавление ошибки для определенных слов.
        /// </summary>
        /// <example>
        ///     -- Coding4fun.IgnoreWordValidation: IDКонстракта
        ///     DECLARE @invalidWord NVARCHAR(MAX) = N'IDКонстракта'
        /// </example>
        private static readonly Regex IgnoreWordRegex =
            new Regex($@"--\s*{ExtendedKeywords.IgnoreWordValidation}:\s*(?<word>.+)",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public StringLiteralRule() => SupportedElementTypes = new List<ModelTypeClass>
        {
            ModelSchema.ServerDdlTrigger,
            ModelSchema.DatabaseDdlTrigger,
            ModelSchema.DmlTrigger,
            ModelSchema.SqlFile,
            ModelSchema.TableValuedFunction,
            ModelSchema.ScalarFunction,
            ModelSchema.Procedure,
            ModelSchema.PartitionFunction
        };

        /// <inheritdoc />
        protected override string GetWarningDescription(ValidationResult validationResult)
        {
            var identifier = ((StringLiteral)validationResult.InvalidObject).Value;
            return string.Format(RuleResources.StringLiteral_ProblemDescription, identifier);
        }

        /// <inheritdoc />
        protected override void InitializeVisitor(StringLiteralVisitor visitor,
            SqlRuleExecutionContext ruleExecutionContext)
        {
            visitor.SetPattern(ConfigLoaderBuildContributor.StringLiteralInvalidPattern);

            // Получение списка подавлений.
            var ignoreWords = ruleExecutionContext.ScriptFragment
                .ScriptTokenStream
                .Where(s => s.TokenType == TSqlTokenType.SingleLineComment)
                .Select(token =>
                {
                    var match = IgnoreWordRegex.Match(token.Text);
                    return match.Success ? match.Groups["word"].Value : null;
                })
                .Where(word => word != null)
                .ToArray();

            if (ignoreWords.Any()) visitor.AddIgnoredWords(ignoreWords);
        }
    }
}