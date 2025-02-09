using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Rules;

/// <summary>
/// Finds defined variables, that were never used.
/// </summary>
[LocalizedExportCodeAnalysisRule(RuleCodes.Rule006,
    nameof(RuleResources.VariableUsage_RuleName),
    Category = RuleCategories.Design,
    RuleScope = SqlRuleScope.Element)]
public class VariableUsageRule : SqlCodeAnalysisRuleBase<VariableUsageVisitor>
{
    /// <summary>
    /// Initialization.
    /// </summary>
    public VariableUsageRule() => SupportedElementTypes =
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

    /// <inheritdoc/>
    protected override string GetWarningDescription(ValidationResult validationResult)
    {
        string varName = ((Identifier)validationResult.InvalidObject).Value;
        return string.Format(RuleResources.VariableUsage_ProblemDescription, varName);
    }
}