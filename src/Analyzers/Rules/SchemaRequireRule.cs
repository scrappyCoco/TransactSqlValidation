using System.Linq;
using Coding4Fun.TransactSql.Analyzers.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Rules;

/// <summary>
/// This rule enforces to necessarily write schema name in queries.
/// 
/// Smelling code:
/// <code>
/// SELECT *
/// FROM Product;
/// </code>
/// 
/// Better code:
/// <code>
/// SELECT *
/// FROM Product;
/// </code>
/// </summary>
[LocalizedExportCodeAnalysisRule(RuleCodes.Rule002,
    nameof(RuleResources.SchemaRequire_RuleName),
    Category = RuleCategories.Design,
    RuleScope = SqlRuleScope.Element)]
public sealed class SchemaRequireRule : SqlCodeAnalysisRuleBase<SchemaRequireVisitor>
{
    /// <summary>
    /// Initialization.
    /// </summary>
    public SchemaRequireRule() => SupportedElementTypes =
        [
            ModelSchema.Procedure,
            ModelSchema.TableValuedFunction,
            ModelSchema.ScalarFunction
        ];

    /// <inheritdoc />
    protected override string GetWarningDescription(ValidationResult validationResult)
    {
        var identifiersPath = string.Join(".",
            ((NamedTableReference)validationResult.InvalidObject).SchemaObject.Identifiers.Select(i => i.Value));
        return string.Format(RuleResources.SchemaRequire_ProblemDescription, identifiersPath);
    }
}