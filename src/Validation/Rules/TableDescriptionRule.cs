using System;
using System.Linq;
using Coding4fun.TransactSql.Validations.Extensions;
using Coding4fun.TransactSql.Validations.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Result = Coding4fun.TransactSql.Validations.ValidationResults.TableDescriptionValidationResult;

namespace Coding4fun.TransactSql.Validations.Rules
{
    [LocalizedExportCodeAnalysisRule(RuleCodes.Rule004,
        nameof(RuleResources.TableDescription_RuleName),
        Category = RuleCategories.Design,
        RuleScope = SqlRuleScope.Element)]
    public class TableDescriptionRule : SqlCodeAnalysisRuleBase<TableDescriptionVisitor>
    {
        /// <summary>
        ///     Стандартное свойство для описания объектов MS SQL.
        /// </summary>
        /// <example>
        ///     EXECUTE sp_AddExtendedProperty @name = N'MS_Description'
        ///     , @value = 'TABLE'
        ///     , @level0type = N'SCHEMA', @level0name = N'dbo'
        ///     , @level1type = N'TABLE' , @level1name = N'MY_TABLE';
        /// </example>
        private const string MsDescriptionPropertyName = "MS_Description";

        public TableDescriptionRule()
        {
            SupportedElementTypes = new[]
            {
                ModelSchema.Table
            };
        }

        /// <inheritdoc />
        protected override string GetWarningDescription(ValidationResult validationResult)
        {
            var resultCode = (Result)validationResult.ResultCode;
            var identifier = ((Identifier)validationResult.InvalidObject).Value;
            switch (resultCode)
            {
                case Result.ColumnDoesNotContainDescription:
                    return string.Format(RuleResources.TableDescription_ColumnDoesNotContainDescription, identifier);
                case Result.TableDoesNotContainDescription:
                    return string.Format(RuleResources.TableDescription_TableDoesNotContainDescription, identifier);
                default:
                    throw new InvalidOperationException($"Unable to find message for {resultCode}.");
            }
        }

        /// <inheritdoc />
        protected override void InitializeVisitor(TableDescriptionVisitor visitor,
            SqlRuleExecutionContext ruleExecutionContext)
        {
            var table = ruleExecutionContext.ModelElement;
            if (!table.HasExtendedProperty(MsDescriptionPropertyName))
                if (ruleExecutionContext.ScriptFragment is CreateTableStatement createTableStatement)
                    visitor.AddValidationResult((int)Result.TableDoesNotContainDescription,
                        createTableStatement.SchemaObjectName.BaseIdentifier);

            var columnsWithDescription = table.GetChildren()
                .Where(column => column.ObjectType == ModelSchema.Column &&
                                 column.HasExtendedProperty(MsDescriptionPropertyName))
                .Select(column => column.Name.Parts.Last())
                .ToArray();

            visitor.AddDocumentedColumnName(columnsWithDescription);

            base.InitializeVisitor(visitor, ruleExecutionContext);
        }
    }
}