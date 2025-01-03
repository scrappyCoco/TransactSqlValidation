using System.Collections.Generic;
using System.Text.RegularExpressions;
using Coding4Fun.TransactSql.Analyzers.ValidationResults;

namespace Coding4Fun.TransactSql.Analyzers.Configuration;

/// <summary>
/// Configuration for SQL analyzers.
/// </summary>
public class SqlAnalysisConfiguration
{
    /// <summary>
    /// Naming rules for SQL object.
    /// </summary>
    public Dictionary<ObjectNameValidationResult, NamingRule>? Naming { get; init; }
    
    /// <summary>
    /// Pattern, that can't be matched for word (for example mix of cyrillic and latin symbols in one word). 
    /// </summary>
    public Regex? InvalidWordMixPattern { get; init; }
}