using Coding4Fun.TransactSql.Analyzers.Visitors;

namespace Coding4Fun.TransactSql.Analyzers.ValidationResults;

/// <summary>
/// Validation result for <see cref="SchemaRequireVisitor"/>.
/// </summary>
public enum SchemaRequireValidationResult
{
    /// <summary>
    /// A reference to SQL object has invalid path.
    /// </summary>
    InvalidPath
}