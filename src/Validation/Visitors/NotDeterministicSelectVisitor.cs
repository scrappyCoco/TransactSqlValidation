using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.Validations.Visitors
{
    public class NotDeterministicSelectVisitor : SqlVisitorBase
    {
        public override void Visit(QuerySpecification querySpecification)
        {
            var hasTopWithoutOrderBy =
                querySpecification.TopRowFilter != null && querySpecification.OrderByClause == null;

            if (!hasTopWithoutOrderBy) return;

            var isInsideExists = false;
            if (querySpecification.FirstTokenIndex > 0)
            {
                var previousToken = querySpecification.ScriptTokenStream
                    .Take(querySpecification.FirstTokenIndex - 1)
                    .Reverse()
                    .FirstOrDefault(token => token.IsKeyword());

                if (previousToken?.TokenType == TSqlTokenType.Exists) isInsideExists = true;
            }

            if (!isInsideExists) AddValidationResult(0, querySpecification.TopRowFilter);
        }
    }
}