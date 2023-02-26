using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.Validations.Visitors
{
    public class StringLiteralVisitor : SqlVisitorBase
    {
        private HashSet<string> _ignoredWords;
        private Regex _mixCharacterRegex;

        /// <inheritdoc />
        public override void Visit(StringLiteral stringLiteral)
        {
            if (_mixCharacterRegex.IsMatch(stringLiteral.Value) &&
                (_ignoredWords == null || !_ignoredWords.Contains(stringLiteral.Value)))
                AddValidationResult(0, stringLiteral);
        }

        public void AddIgnoredWords(string[] ignoreWords)
        {
            if (ignoreWords == null || !ignoreWords.Any()) return;

            if (_ignoredWords == null) _ignoredWords = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

            foreach (var ignoreWord in ignoreWords) _ignoredWords.Add(ignoreWord);
        }

        public void AddIgnoreWord(string ignoreWord)
        {
            if (string.IsNullOrWhiteSpace(ignoreWord)) return;
            if (_ignoredWords == null) _ignoredWords = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

            _ignoredWords.Add(ignoreWord);
        }

        public void SetPattern(string regexPattern)
        {
            _mixCharacterRegex = new Regex(regexPattern, RegexOptions.Compiled);
        }
    }
}