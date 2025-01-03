using System;
using System.Linq;
using Coding4Fun.TransactSql.Analyzers.Extensions;
using Coding4Fun.TransactSql.Analyzers.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Result = Coding4Fun.TransactSql.Analyzers.ValidationResults.TableDescriptionValidationResult;

namespace Coding4Fun.TransactSql.Analyzers.Rules;

/// <summary>
/// Checks that table and all columns contain description.
/// 
/// Smelling code:
/// <code>
/// CREATE TABLE Production.Product (ProductID int IDENTITY(1,1) NOT NULL);
/// </code>
/// 
/// Better:
/// <code>
/// CREATE TABLE Production.Product (ProductID int IDENTITY(1,1) NOT NULL);
/// GO
/// 
/// EXEC sys.sp_AddExtendedProperty @name       = N'MS_Description',
///                                 @value      = N'Primary key for Product records.',
///                                 @level0type = N'SCHEMA', @level0name = N'Production',
///                                 @level1type = N'TABLE',  @level1name = N'Product',
///                                 @level2type = N'COLUMN', @level2name = N'ProductID';
/// GO
/// -- And similar description for the table.
/// </code>
/// </summary>
[LocalizedExportCodeAnalysisRule(RuleCodes.Rule004,
    nameof(RuleResources.TableDescription_RuleName),
    Category = RuleCategories.Design,
    RuleScope = SqlRuleScope.Element)]
public class TableDescriptionRule : SqlCodeAnalysisRuleBase<TableDescriptionVisitor>
{
    /// <summary>
    /// A standard property for describing MS SQL objects.
    /// </summary>
    /// <code>
    ///     EXECUTE sp_AddExtendedProperty @name = N'MS_Description'
    ///     , @value = 'TABLE'
    ///     , @level0type = N'SCHEMA', @level0name = N'dbo'
    ///     , @level1type = N'TABLE' , @level1name = N'MY_TABLE';
    /// </code>
    private const string MsDescriptionPropertyName = "MS_Description";

    /// <summary>
    /// Initialization.
    /// </summary>
    public TableDescriptionRule() => SupportedElementTypes = [ModelSchema.Table];

    /// <inheritdoc />
    protected override string GetWarningDescription(ValidationResult validationResult)
    {
        Result resultCode = (Result)validationResult.ResultCode;
        string? identifier = ((Identifier)validationResult.InvalidObject).Value;
        return resultCode switch
        {
            Result.ColumnDoesNotContainDescription => string.Format(
                RuleResources.TableDescription_ColumnDoesNotContainDescription, identifier),
            Result.TableDoesNotContainDescription => string.Format(
                RuleResources.TableDescription_TableDoesNotContainDescription, identifier),
            _ => throw new InvalidOperationException($"Unable to find message for {resultCode}.")
        };
    }

    /// <inheritdoc />
    protected override void InitializeVisitor(TableDescriptionVisitor visitor,
        SqlRuleExecutionContext ruleExecutionContext)
    {
        TSqlObject? table = ruleExecutionContext.ModelElement;
        if (!table.HasExtendedProperty(MsDescriptionPropertyName))
            if (ruleExecutionContext.ScriptFragment is CreateTableStatement createTableStatement)
                visitor.AddValidationResult((int)Result.TableDoesNotContainDescription,
                    createTableStatement.SchemaObjectName.BaseIdentifier);

        string[] columnsWithDescription = table.GetChildren()
            .Where(column => column.ObjectType == ModelSchema.Column &&
                             column.HasExtendedProperty(MsDescriptionPropertyName))
            .Select(column => column.Name.Parts.Last())
            .ToArray();

        visitor.AddDocumentedColumnName(columnsWithDescription);

        base.InitializeVisitor(visitor, ruleExecutionContext);
    }
}