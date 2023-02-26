using System.Linq;
using Coding4fun.TransactSql.Validations.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.Validations.Rules
{
    [LocalizedExportCodeAnalysisRule(RuleCodes.Rule002,
        nameof(RuleResources.SchemaRequire_RuleName),
        Category = RuleCategories.Design,
        RuleScope = SqlRuleScope.Element)]
    public sealed class SchemaRequireRule : SqlCodeAnalysisRuleBase<SchemaRequireVisitor>
    {
        public SchemaRequireRule()
        {
            SupportedElementTypes = new[]
            {
                ModelSchema.Procedure,
                ModelSchema.TableValuedFunction,
                ModelSchema.ScalarFunction
            };
        }

        /// <inheritdoc />
        protected override string GetWarningDescription(ValidationResult validationResult)
        {
            var identifiersPath = string.Join(".",
                ((NamedTableReference)validationResult.InvalidObject).SchemaObject.Identifiers.Select(i => i.Value));
            return string.Format(RuleResources.SchemaRequire_ProblemDescription, identifiersPath);
        }
    }
}