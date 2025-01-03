using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Coding4Fun.TransactSql.Analyzers.Configuration;
using Coding4Fun.TransactSql.Analyzers.ValidationResults;

namespace Coding4Fun.TransactSql.Analyzers;

/// <summary>
/// Parser, that reads configuration of sql validation.
/// Each configuration value is represented in the following format:
/// <code>[Key] = [Value]</code>
/// where [Key] starts with:
/// <code>Coding4Fun.ObjectName</code>
/// for example:
/// <code>
/// Coding4Fun.ObjectName.LATIN_UPPER_CASE = [A-Z][A-Z0-9]*(_[A-Z0-9])*?;
/// Coding4Fun.ObjectName.Table = ^(\[{Schema}\]\.\[MY_{LATIN_UPPER_CASE}\]|\[import\].+)$;
/// </code>
/// </summary>
public static class ConfigurationParser
{
    private const string NamingRuleNamespace = "Coding4Fun.ObjectName.";
    private const string InvalidWordMixPattern = "Coding4Fun.StringLiteral.InvalidWordMixPattern";
    private const string VariablePrefix = "{";
    private const string VariableSuffix = "}";

    /// <example>
    /// Coding4Fun.ObjectName.LATIN_UPPER_CASE = [A-Z][A-Z0-9]*(_[A-Z0-9])*?;
    /// Coding4Fun.ObjectName.Table = ^(\[{Schema}\]\.\[MY_{LATIN_UPPER_CASE}\]|\[import\].+)$;
    ///                                   ^      ^
    /// </example>
    private static readonly Regex VariableRegex =
        new(VariablePrefix + @"(?<var>\w+)" + VariableSuffix, RegexOptions.Compiled);

    /// <example>
    /// Coding4Fun.ObjectName.LATIN_UPPER_CASE = [A-Z][A-Z0-9]*(_[A-Z0-9])*?;
    /// Coding4Fun.ObjectName.Table = ^(\[{Schema}\]\.\[MY_{LATIN_UPPER_CASE}\]|\[import\].+)$;
    /// ^                         ^   ^                                                       ^
    /// ======= Key ==============    ============= Value =====================================
    /// </example>
    private static readonly Regex KeyValuePairRegex =
        new(@"^(?<key>[a-zA-Z0-9._]+)\s*=\s*(?<value>[^;]+);$", RegexOptions.Compiled);

    private static readonly HashSet<string> ObjectNamingVariables =
        ((ObjectNameValidationResult[])Enum.GetValues(typeof(ObjectNameValidationResult)))
        .Select(variable => variable.ToString())
        .ToHashSet();

    private static SqlAnalysisConfiguration ComposeRules(
        KeyValuePair<string, string>[] configLines)
    {
        Dictionary<string, string> userDefinedVariables = [];
        Dictionary<ObjectNameValidationResult, NamingRule> rules = [];
        string? invalidWordMixPattern = null;

        foreach (KeyValuePair<string, string> configLine in configLines)
        {
            string configName = configLine.Key;
            string configValue = configLine.Value;
            
            // Substituting variables, for example:
            // configValue:
            //   ({CyrillicChar}{LatinChar})|({LatinChar}{CyrillicChar});
            // compiledValue:
            //   ([а-яА-ЯёЁ][a-zA-Z])|([a-zA-Z][а-яА-ЯёЁ])
            string compiledValue = VariableRegex.Replace(configValue, varGroup =>
            {
                string varName = varGroup.Groups["var"].Value;
                if (ObjectNamingVariables.Contains(varName)) return varGroup.Value;
                if (!userDefinedVariables.TryGetValue(varName, out string? varValue))
                    throw new SqlValidationException($"Unable to find value for variable {varName}");
                return varValue;
            });

            if (configName.StartsWith(NamingRuleNamespace))
            {
                configName = configName.Replace(NamingRuleNamespace, "");

                if (ObjectNamingVariables.Contains(configName))
                {
                    ObjectNameValidationResult objectKind =
                        (ObjectNameValidationResult)Enum.Parse(typeof(ObjectNameValidationResult), configName);
                    rules.Add(objectKind, new NamingRule(objectKind, configValue, compiledValue));
                }
            }
            else if (configName == InvalidWordMixPattern)
            {
                invalidWordMixPattern = compiledValue;
            }
            else
            {
                userDefinedVariables.Add(configName, configValue);
            }
        }

        return new SqlAnalysisConfiguration
        {
            Naming = rules,
            InvalidWordMixPattern = invalidWordMixPattern == null
                ? null
                : new Regex(invalidWordMixPattern, RegexOptions.Compiled, TimeSpan.FromSeconds(1d))
        };
    }

    /// <summary>
    /// Parsing configuration for SQL validators from the text.
    /// </summary>
    /// <param name="streamReader">Text with configuration.</param>
    /// <returns>Parsed configuration.</returns>
    public static SqlAnalysisConfiguration Parse(TextReader streamReader)
    {
        KeyValuePair<string, string>[] configLines = streamReader.ReadToEnd()
            .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
            .Select(line => KeyValuePairRegex.Match(line))
            .Select(match =>
                new KeyValuePair<string, string>(match.Groups["key"].Value, match.Groups["value"].Value))
            .ToArray();

        return ComposeRules(configLines);
    }
}