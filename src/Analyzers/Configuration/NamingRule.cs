using Coding4Fun.TransactSql.Analyzers.ValidationResults;

namespace Coding4Fun.TransactSql.Analyzers.Configuration;

/// <summary>
/// Naming rule for a SQL object.
/// </summary>
/// <param name="ObjectKind">Type of SQL object.</param>
/// <param name="OriginalPattern">Regex-like pattern with user-defined variables that will be substituted with defined regex.</param>
/// <param name="CompiledPattern"><paramref name="OriginalPattern"/>, where user-defined variables were substituted with regex.</param>
public record NamingRule(
    ObjectNameValidationResult ObjectKind,
    string OriginalPattern,
    string CompiledPattern);