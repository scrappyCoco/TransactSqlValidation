using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Coding4fun.TransactSql.Validations.ValidationResults;

namespace Coding4fun.TransactSql.Validations
{
    public static class NamingRuleParser
    {
        private const string RuleNamespace = "Coding4fun.ObjectName.";
        private const string VariablePrefix = "{";
        private const string VariableSuffix = "}";

        private static readonly Regex VariableRegex =
            new Regex(VariablePrefix + @"(?<var>\w+)" + VariableSuffix, RegexOptions.Compiled);

        private static readonly Regex KeyValuePairRegex =
            new Regex(@"^(?<key>[a-zA-Z0-9._]+)\s*=\s*(?<value>[^;]+);$", RegexOptions.Compiled);

        private static readonly HashSet<string> SystemVariables =
            ((ObjectNameValidationResult[])Enum.GetValues(typeof(ObjectNameValidationResult)))
            .Select(variable => variable.ToString())
            .ToHashSet();

        private static Dictionary<ObjectNameValidationResult, string> ComposeRules(
            Func<IEnumerable<KeyValuePair<string, string>>> argumentsCollector)
        {
            var userDefinedVariables = new Dictionary<string, string>();
            var rules = new Dictionary<ObjectNameValidationResult, string>();

            var arguments = argumentsCollector.Invoke().ToArray();
            foreach (var argument in arguments)
            {
                var argumentName = argument.Key;
                var argumentValue = argument.Value;

                if (!argumentName.StartsWith(RuleNamespace)) continue;
                argumentName = argumentName.Replace(RuleNamespace, "");

                argumentValue = VariableRegex.Replace(argumentValue, varGroup =>
                {
                    var varName = varGroup.Groups["var"].Value;
                    if (SystemVariables.Contains(varName)) return varGroup.Value;
                    if (!userDefinedVariables.TryGetValue(varName, out var varValue))
                        throw new KeyNotFoundException($"Unable to find value for variable {varName}");
                    return varValue;
                });

                if (SystemVariables.Contains(argumentName))
                {
                    var objectKind =
                        (ObjectNameValidationResult)Enum.Parse(typeof(ObjectNameValidationResult), argumentName);
                    rules.Add(objectKind, argumentValue);
                }
                else
                {
                    userDefinedVariables.Add(argumentName, argumentValue);
                }
            }

            return rules;
        }

        public static Dictionary<ObjectNameValidationResult, string> ParseTextFile(TextReader streamReader)
        {
            return ComposeRules(() => streamReader.ReadToEnd()
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => KeyValuePairRegex.Match(line))
                .Select(match =>
                    new KeyValuePair<string, string>(match.Groups["key"].Value, match.Groups["value"].Value)));
        }

        public static Dictionary<ObjectNameValidationResult, string> ParseContributorArguments(
            IDictionary<string, string> arguments) =>
            ComposeRules(arguments.ToArray);
    }
}