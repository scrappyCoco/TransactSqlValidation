using System;
using System.Collections.Generic;
using System.Linq;
using Coding4fun.TransactSql.Validations.ValidationResults;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.Validations.Visitors
{
    public class SchemaRequireVisitor : SqlVisitorBase
    {
        private readonly HashSet<string> _cteNames = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase);

        public override void ExplicitVisit(SelectStatement statement) => ExplicitVisitStatement(statement);

        public override void ExplicitVisit(InsertStatement statement)
        {
            ExplicitVisitStatement(statement);
        }

        public override void ExplicitVisit(UpdateStatement statement)
        {
            if (!HasFromClause(statement.UpdateSpecification)) return;
            ExplicitVisitStatement(statement);
        }

        public override void ExplicitVisit(DeleteStatement statement)
        {
            if (!HasFromClause(statement.DeleteSpecification)) return;
            ExplicitVisitStatement(statement);
        }

        public override void ExplicitVisit(MergeStatement statement) => ExplicitVisitStatement(statement);

        private static bool HasFromClause(UpdateDeleteSpecificationBase specification) =>
            !(specification.FromClause != null && specification.Target is NamedTableReference);

        private void ExplicitVisitStatement(StatementWithCtesAndXmlNamespaces dmlStatement)
        {
            if (dmlStatement.WithCtesAndXmlNamespaces?.CommonTableExpressions?.Any() ?? false)
            {
                var cteNames = dmlStatement
                    .WithCtesAndXmlNamespaces.CommonTableExpressions
                    .Select(cte => cte.ExpressionName.Value);

                foreach (var cteName in cteNames) _cteNames.Add(cteName);
            }

            dmlStatement.AcceptChildren(this);
            _cteNames.Clear();
        }

        /// <inheritdoc />
        public override void ExplicitVisit(NamedTableReference namedTableReference)
        {
            var objectName = namedTableReference.SchemaObject.BaseIdentifier.Value;
            if (objectName.StartsWith("#")) return;
            if (namedTableReference.SchemaObject.Identifiers.Count == 1 && _cteNames.Contains(objectName)) return;
            if (namedTableReference.SchemaObject.Identifiers.Count != 2)
                AddValidationResult((int)SchemaRequireValidationResult.InvalidPath, namedTableReference);
        }
    }
}