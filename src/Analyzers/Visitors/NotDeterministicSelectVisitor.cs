using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Visitors;

/// <summary>
/// Finds SELECT statements with TOP clause and without ORDER BY.
/// </summary>
public class NotDeterministicSelectVisitor : SqlVisitorBase
{
    /// <inheritdoc />
    public override void Visit(QuerySpecification querySpecification)
    {
        bool hasTopWithoutOrderBy =
            querySpecification is { TopRowFilter: not null, OrderByClause: null };

        if (!hasTopWithoutOrderBy) return;

        bool isInsideExists = false;
        if (querySpecification.FirstTokenIndex > 0)
        {
            TSqlParserToken? previousToken = querySpecification.ScriptTokenStream
                .Take(querySpecification.FirstTokenIndex - 1)
                .Reverse()
                .FirstOrDefault(token => token.IsKeyword());

            if (previousToken?.TokenType == TSqlTokenType.Exists) isInsideExists = true;
        }

        if (!isInsideExists) AddValidationResult(0, querySpecification.TopRowFilter!);
    }
}