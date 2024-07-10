using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Visitors;

/// <summary>
/// Base visitor for TSQL validations.
/// </summary>
public abstract class SqlVisitorBase : TSqlFragmentVisitor
{
    private static readonly LinkedList<ValidationResult> EmptyList = [];
    private LinkedList<ValidationResult>? _validationResults;

    /// <summary>
    /// Problems that were found during validation.
    /// </summary>
    public IEnumerable<ValidationResult> ValidationResults => _validationResults ?? EmptyList;

    /// <summary>
    /// Add validation error.
    /// </summary>
    /// <param name="resultCode">Error code.</param>
    /// <param name="invalidFragment">Part of the code with smell.</param>
    public void AddValidationResult(int resultCode, TSqlFragment invalidFragment)
    {
        _validationResults ??= [];
        _validationResults.AddLast(new ValidationResult(invalidFragment, resultCode));
    }
}