using Coding4Fun.TransactSql.Analyzers.Configuration;
using Coding4Fun.TransactSql.Analyzers.ValidationResults;
using Coding4Fun.TransactSql.Analyzers.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Rules;

/// <summary>
/// Check that object names matches with common patterns, that defined in the procedure dbo.SqlAnalysisConfiguration.
/// For example, it checks that all tables must be in upper case, or/and they must start with prefix `TBL_` and so on.
/// For more information about configuration of naming rules explain README.md. 
/// </summary>
[LocalizedExportCodeAnalysisRule(RuleCodes.Rule003,
    nameof(RuleResources.ObjectName_RuleName),
    Category = RuleCategories.Naming,
    RuleScope = SqlRuleScope.Element)]
public class ObjectNameRule : SqlCodeAnalysisRuleBase<ObjectNameVisitor>
{
    /// <inheritdoc />
    public ObjectNameRule() => SupportedElementTypes =
    [
        ModelSchema.Table,
        ModelSchema.Procedure,
        ModelSchema.PartitionFunction,
        ModelSchema.ScalarFunction,
        ModelSchema.TableValuedFunction
    ];

    /// <inheritdoc />
    protected override void InitializeVisitor(ObjectNameVisitor visitor,
        SqlRuleExecutionContext ruleExecutionContext)
    {
        if (SqlAnalysisConfiguration?.Naming == null) return;
        visitor.AddNamingRules(SqlAnalysisConfiguration.Naming);
        base.InitializeVisitor(visitor, ruleExecutionContext);
    }

    /// <inheritdoc />
    protected override string GetWarningDescription(ValidationResult validationResult)
    {
        ObjectNameValidationResult objectKind = (ObjectNameValidationResult)validationResult.ResultCode;
        if (SqlAnalysisConfiguration?.Naming == null)
            throw new SqlValidationException("Naming rules were not specified");
        
        NamingRule? validPattern = SqlAnalysisConfiguration.Naming[objectKind];
        Identifier invalidIdentifier = (Identifier)validationResult.InvalidObject;
        return string.Format(RuleResources.ObjectName_ProblemDescription, invalidIdentifier.Value, validPattern.OriginalPattern);
    }
}