using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers;

/// <summary>
/// The result of visitor's validation.
/// </summary>
public class ValidationResult(TSqlFragment invalidObject, int resultCode)
{
    /// <summary>
    /// The object where were found the error.
    /// </summary>
    public TSqlFragment InvalidObject { get; } = invalidObject;

    /// <summary>
    /// Code of the error.
    /// </summary>
    public int ResultCode { get; } = resultCode;

    /// <inheritdoc />
    public override string ToString() => $"{ResultCode} | {InvalidObject}";
}