using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Result = Coding4fun.TransactSql.Validations.ValidationResults.TableDescriptionValidationResult;

namespace Coding4fun.TransactSql.Validations.Visitors
{
    public class TableDescriptionVisitor : SqlVisitorBase
    {
        /// <summary>
        /// Названия столбцов, у которых есть описание.
        /// </summary>
        private readonly HashSet<string> _columns = new HashSet<string>();

        /// <inheritdoc />
        public override void Visit(ColumnDefinition columnDefinition)
        {
            var columnName = columnDefinition.ColumnIdentifier.Value;
            if (!_columns.Contains(columnName))
                AddValidationResult((int)Result.ColumnDoesNotContainDescription, columnDefinition.ColumnIdentifier);
        }

        /// <summary>
        /// Добавление названий столбцов, у которых есть описание.
        /// </summary>
        /// <param name="columnNames">Названия столбцов с описанием.</param>
        public void AddDocumentedColumnName(IEnumerable<string> columnNames)
        {
            foreach (var columnName in columnNames) _columns.Add(columnName);
        }
    }
}