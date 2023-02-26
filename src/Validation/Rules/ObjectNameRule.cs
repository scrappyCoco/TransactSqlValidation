using System.Collections.Generic;
using Coding4fun.TransactSql.Validations.BuildContributors;
using Coding4fun.TransactSql.Validations.ValidationResults;
using Coding4fun.TransactSql.Validations.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.Validations.Rules
{
    [LocalizedExportCodeAnalysisRule(RuleCodes.Rule003,
        nameof(RuleResources.ObjectName_RuleName),
        Category = RuleCategories.Naming,
        RuleScope = SqlRuleScope.Element)]
    public class ObjectNameRule : SqlCodeAnalysisRuleBase<ObjectNameVisitor>
    {
        private Dictionary<ObjectNameValidationResult, string> _rules;

        /// <inheritdoc />
        public ObjectNameRule() => SupportedElementTypes = new List<ModelTypeClass>
        {
            ModelSchema.Table,
            ModelSchema.Procedure,
            ModelSchema.PartitionFunction,
            ModelSchema.ScalarFunction,
            ModelSchema.TableValuedFunction
        };

        /// <inheritdoc />
        protected override void InitializeVisitor(ObjectNameVisitor visitor,
            SqlRuleExecutionContext ruleExecutionContext)
        {
            _rules = ConfigLoaderBuildContributor.ObjectNamePatterns;
            visitor.AddNamingRules(_rules);
            base.InitializeVisitor(visitor, ruleExecutionContext);
        }

        /// <inheritdoc />
        protected override string GetWarningDescription(ValidationResult validationResult)
        {
            var objectKind = (ObjectNameValidationResult)validationResult.ResultCode;
            var validPattern = _rules[objectKind];
            var invalidIdentifier = (Identifier)validationResult.InvalidObject;
            return string.Format(RuleResources.ObjectName_ProblemDescription, invalidIdentifier.Value, validPattern);
        }
    }
}