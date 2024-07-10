namespace Coding4Fun.TransactSql.Analyzers;

/// <summary>
/// Keywords, that used as hints for analyzers inside the SQL. 
/// </summary>
public static class ExtendedKeywords
{
    /// <summary>
    /// The word, following after this keyword, will be skipped during the text validation. 
    /// </summary>
    public const string IgnoreWordValidation = "Coding4Fun.IgnoreWordValidation";
        
    /// <summary>
    /// Keyword for skipping the text validation for the whole SQL object.
    /// </summary>
    public const string IgnoreObjectNameValidation = "Coding4Fun.IgnoreObjectNameValidation";
}