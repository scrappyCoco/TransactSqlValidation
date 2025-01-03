using Coding4Fun.TransactSql.Analyzers.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;

namespace Coding4Fun.TransactSql.Analyzers.Rules;

/// <summary>
/// Checks for existence of ORDER BY clause when fetching rows with SELECT TOP (N).
/// 
/// Smelling code:
/// <code>
/// SELECT TOP (10) *
/// FROM Production.Product;
/// </code>
/// 
/// Better version:
/// <code>
/// SELECT TOP (10) *
/// FROM Production.Product
/// ORDER BY ProductID;
/// </code>
/// </summary>
[LocalizedExportCodeAnalysisRule(RuleCodes.Rule005,
    nameof(RuleResources.NotDeterministicSelect_RuleName),
    Category = RuleCategories.Naming,
    RuleScope = SqlRuleScope.Element)]
public class NotDeterministicSelectRule : SqlCodeAnalysisRuleBase<NotDeterministicSelectVisitor>
{
    /// <summary>
    /// Initialize.
    /// </summary>
    public NotDeterministicSelectRule() => SupportedElementTypes =
    [
        ModelSchema.Procedure,
        ModelSchema.ScalarFunction,
        ModelSchema.TableValuedFunction
    ];

    /// <inheritdoc />
    protected override string GetWarningDescription(ValidationResult validationResult) =>
        RuleResources.NotDeterministicSelect_Description;
}