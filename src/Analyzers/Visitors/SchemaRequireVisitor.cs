using System;
using System.Collections.Generic;
using System.Linq;
using Coding4Fun.TransactSql.Analyzers.ValidationResults;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Visitors;

/// <summary>
/// Checks that references to SQL objects contain schema name.
/// 
/// Smelling code:
/// <code>
/// SELECT *
/// FROM Product;
/// </code>
/// 
/// Better code:
/// <code>
/// SELECT *
/// FROM Product;
/// </code>
/// </summary>
public class SchemaRequireVisitor : SqlVisitorBase
{
    private readonly HashSet<string> _cteNames = new(StringComparer.CurrentCultureIgnoreCase);

    /// <inheritdoc />
    public override void ExplicitVisit(SelectStatement statement) => ExplicitVisitStatement(statement);

    /// <inheritdoc />
    public override void ExplicitVisit(InsertStatement statement)
    {
        ExplicitVisitStatement(statement);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(UpdateStatement statement)
    {
        if (!HasFromClause(statement.UpdateSpecification)) return;
        ExplicitVisitStatement(statement);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(DeleteStatement statement)
    {
        if (!HasFromClause(statement.DeleteSpecification)) return;
        ExplicitVisitStatement(statement);
    }

    /// <inheritdoc />
    public override void ExplicitVisit(MergeStatement statement) => ExplicitVisitStatement(statement);

    private static bool HasFromClause(UpdateDeleteSpecificationBase specification) =>
        specification is not { FromClause: not null, Target: NamedTableReference };

    private void ExplicitVisitStatement(StatementWithCtesAndXmlNamespaces dmlStatement)
    {
        if (dmlStatement.WithCtesAndXmlNamespaces?.CommonTableExpressions?.Any() ?? false)
        {
            dmlStatement
                .WithCtesAndXmlNamespaces.CommonTableExpressions
                .Select(cte => cte.ExpressionName.Value)
                .ToList()
                .ForEach(cte => _cteNames.Add(cte));
        }

        dmlStatement.AcceptChildren(this);
        _cteNames.Clear();
    }

    /// <inheritdoc />
    public override void ExplicitVisit(NamedTableReference namedTableReference)
    {
        var objectName = namedTableReference.SchemaObject.BaseIdentifier.Value;
        if (objectName.StartsWith('#')) return;
        if (namedTableReference.SchemaObject.Identifiers.Count == 1 && _cteNames.Contains(objectName)) return;
        if (namedTableReference.SchemaObject.Identifiers.Count != 2)
            AddValidationResult((int)SchemaRequireValidationResult.InvalidPath, namedTableReference);
    }
}