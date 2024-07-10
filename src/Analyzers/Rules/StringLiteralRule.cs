using System.Linq;
using System.Text.RegularExpressions;
using Coding4Fun.TransactSql.Analyzers.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Rules;

/// <summary>
/// Checking string values for invalid values (for example, a combination of Cyrillic and Latin letters in one word).
/// To read exceptions from comments, you need to enable sqlproj
/// <code>&lt;IgnoreComments&gt;False&lt;/IgnoreComments&gt;</code>
/// </summary>
[LocalizedExportCodeAnalysisRule(RuleCodes.Rule001,
    nameof(RuleResources.StringLiteral_RuleName),
    Category = RuleCategories.Naming,
    RuleScope = SqlRuleScope.Element)]
public class StringLiteralRule : SqlCodeAnalysisRuleBase<StringLiteralVisitor>
{
    /// <summary>
    /// Suppress some words from validation.
    /// </summary>
    /// <example>
    ///     -- Coding4Fun.IgnoreWordValidation: IDКонтракта.
    ///     DECLARE @invalidWord NVARCHAR(MAX) = N'IDКонтракта';
    ///     -- This word will be excluded during validation.
    /// </example>
    private static readonly Regex IgnoreWordRegex =
        new($@"--\s*{ExtendedKeywords.IgnoreWordValidation}:\s*(?<word>.+)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>
    /// Initialization.
    /// </summary>
    public StringLiteralRule() => SupportedElementTypes =
    [
        ModelSchema.ServerDdlTrigger,
        ModelSchema.DatabaseDdlTrigger,
        ModelSchema.DmlTrigger,
        ModelSchema.SqlFile,
        ModelSchema.TableValuedFunction,
        ModelSchema.ScalarFunction,
        ModelSchema.Procedure,
        ModelSchema.PartitionFunction
    ];

    /// <inheritdoc />
    protected override string GetWarningDescription(ValidationResult validationResult)
    {
        string? identifier = ((StringLiteral)validationResult.InvalidObject).Value;
        return string.Format(RuleResources.StringLiteral_ProblemDescription, identifier);
    }

    /// <inheritdoc />
    protected override void InitializeVisitor(StringLiteralVisitor visitor,
        SqlRuleExecutionContext ruleExecutionContext)
    {
        if (SqlAnalysisConfiguration?.InvalidWordMixPattern != null)
        {
            visitor.SetPattern(SqlAnalysisConfiguration?.InvalidWordMixPattern!);    
        }

        // Getting the words that will be excluded from analysis.
        string[] ignoreWords = ruleExecutionContext.ScriptFragment
            .ScriptTokenStream
            .Where(s => s.TokenType == TSqlTokenType.SingleLineComment)
            .Select(token =>
            {
                Match match = IgnoreWordRegex.Match(token.Text);
                return match.Success ? match.Groups["word"].Value : null;
            })
            .Where(word => word != null)
            .Select(word => word!)
            .ToArray();

        if (ignoreWords.Length != 0) visitor.AddIgnoredWords(ignoreWords);
    }
}