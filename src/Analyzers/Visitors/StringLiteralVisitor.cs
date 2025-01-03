using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Visitors;

/// <summary>
/// Checking string values for invalid values (for example, a combination of Cyrillic and Latin letters in one word).
/// </summary>
public class StringLiteralVisitor : SqlVisitorBase
{
    private HashSet<string>? _ignoredWords;
    private Regex? _mixCharacterRegex = new ("[а-яА-ЯёЁ][a-zA-Z]", RegexOptions.Compiled, TimeSpan.FromSeconds(1d));

    /// <inheritdoc />
    public override void Visit(StringLiteral stringLiteral)
    {
        if (_mixCharacterRegex == null) throw new SqlValidationException($"{nameof(StringLiteralVisitor)} has uninitialized mixed character regex");
        if (_mixCharacterRegex.IsMatch(stringLiteral.Value) &&
            (_ignoredWords == null || !_ignoredWords.Contains(stringLiteral.Value)))
            AddValidationResult(0, stringLiteral);
    }

    /// <summary>
    /// Add words, that must be suppressed by analyzer.
    /// </summary>
    public void AddIgnoredWords(string[]? ignoreWords)
    {
        if (ignoreWords == null || ignoreWords.Length == 0) return;
        _ignoredWords ??= new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
        foreach (var ignoreWord in ignoreWords) _ignoredWords.Add(ignoreWord);
    }

    /// <summary>
    /// Add word, that must be suppressed by analyzer.
    /// </summary>
    public void AddIgnoreWord(string ignoreWord)
    {
        if (string.IsNullOrWhiteSpace(ignoreWord)) return;
        _ignoredWords ??= new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
        _ignoredWords.Add(ignoreWord);
    }

    /// <summary>
    /// Set the pattern, that will add error during validation if it matches.
    /// </summary>
    public void SetPattern(Regex invalidRegex) => _mixCharacterRegex = invalidRegex;
}