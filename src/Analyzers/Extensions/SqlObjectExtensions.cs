using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Extensions;

/// <summary>
/// Extensions for <see cref="TSqlObject"/>.
/// </summary>
public static class SqlObjectExtensions
{
    /// <summary>
    /// A value of a string literal.
    /// </summary>
    /// <example>
    /// DECLARE @val NVARCHAR(MAX) = N'Some useful string';
    ///                                ^                ^
    /// </example>
    private static readonly Regex StringLiteralRegex = new ("^N?'(?<value>.+?)'$");

    /// <summary>
    /// Does <paramref name="sqlObject"/> contain property with name <paramref name="propertyName"/>.
    /// </summary>
    public static bool HasExtendedProperty(this TSqlObject sqlObject, string propertyName) =>
        sqlObject.GetChildren()
            .Where(child =>
                child.ObjectType == ModelSchema.ExtendedProperty
                && child.Name.Parts.Last() == propertyName)
            .Select(propertyObject => propertyObject.GetProperty(ExtendedProperty.Value).ToString())
            .Any(propertyValue => !string.IsNullOrWhiteSpace(propertyValue));

    /// <summary>
    /// Get a value of <paramref name="propertyName"/> for <paramref name="sqlObject"/>.
    /// </summary>
    public static string? GetExtendedPropertyValue(this TSqlObject sqlObject, string propertyName)
    {
        string? stringLiteral = sqlObject.GetChildren()
            .Where(child =>
                child.ObjectType == ModelSchema.ExtendedProperty
                && child.Name.Parts.Last() == propertyName)
            .Select(propertyObject => propertyObject.GetProperty(ExtendedProperty.Value))
            .FirstOrDefault()
            ?.ToString();

        if (stringLiteral == null) return null;
        var stringLiteralMatch = StringLiteralRegex.Match(stringLiteral);
        return !stringLiteralMatch.Success ? null : stringLiteralMatch.Groups["value"].Value;
    }

    /// <summary>
    /// Build path from elements.
    /// </summary>
    public static string GetPath(this IEnumerable<Identifier> identifiers) => identifiers
        .Select(i => i.Value.StartsWith('[') ? i.Value : "[" + i.Value + "]")
        .Let(quotedIdentifiers => string.Join(".", quotedIdentifiers));
}