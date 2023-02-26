using System.Collections.Generic;
using Coding4fun.TransactSql.Validations.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;

namespace Coding4fun.TransactSql.Validations.Rules
{
    [LocalizedExportCodeAnalysisRule(RuleCodes.Rule005,
        nameof(RuleResources.NotDeterministicSelect_RuleName),
        Category = RuleCategories.Naming,
        RuleScope = SqlRuleScope.Element)]
    public class NotDeterministicSelectRule : SqlCodeAnalysisRuleBase<NotDeterministicSelectVisitor>
    {
        public NotDeterministicSelectRule() =>
            SupportedElementTypes = new List<ModelTypeClass>
            {
                ModelSchema.Procedure,
                ModelSchema.ScalarFunction,
                ModelSchema.TableValuedFunction
            };

        /// <inheritdoc />
        protected override string GetWarningDescription(ValidationResult validationResult) =>
            RuleResources.NotDeterministicSelect_Description;
    }
}