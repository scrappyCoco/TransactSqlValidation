using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Result = Coding4Fun.TransactSql.Analyzers.ValidationResults.TableDescriptionValidationResult;

namespace Coding4Fun.TransactSql.Analyzers.Visitors;

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
public class TableDescriptionVisitor : SqlVisitorBase
{
    /// <summary>
    /// Column names, that contain description.
    /// </summary>
    private readonly HashSet<string> _columns = [];

    /// <inheritdoc />
    public override void Visit(ColumnDefinition columnDefinition)
    {
        string? columnName = columnDefinition.ColumnIdentifier.Value;
        if (!_columns.Contains(columnName))
            AddValidationResult((int)Result.ColumnDoesNotContainDescription, columnDefinition.ColumnIdentifier);
    }

    /// <summary>
    /// Add column name, that contain description.
    /// </summary>
    /// <param name="columnNames">Column names.</param>
    public void AddDocumentedColumnName(IEnumerable<string> columnNames)
    {
        foreach (var columnName in columnNames) _columns.Add(columnName);
    }
}