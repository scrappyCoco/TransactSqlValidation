using System.Collections.Generic;
using System.Linq;
using Coding4fun.TransactSql.Validations.ValidationResults;
using Microsoft.SqlServer.Dac.Deployment;
using Microsoft.SqlServer.Dac.Extensibility;

namespace Coding4fun.TransactSql.Validations.BuildContributors
{
    /// <summary>
    ///     Загружчик конфигурации из sqlproj.
    /// </summary>
    [ExportBuildContributor("Coding4fun.ConfigLoaderBuildContributor", "1.0.0.0")]
    public class ConfigLoaderBuildContributor : BuildContributor
    {
        /// <summary>
        ///     Список правил по наименованию объектов.
        /// </summary>
        public static Dictionary<ObjectNameValidationResult, string> ObjectNamePatterns =
            new Dictionary<ObjectNameValidationResult, string>();

        /// <summary>
        ///     Шаблон запретного строкового литерала.
        ///     В качестве значения по умолчанию указан запрет на сочетание кириллицы с латиницей в одном слове.
        /// </summary>
        public static string StringLiteralInvalidPattern = @"([а-яА-ЯёЁ][a-zA-Z])|([a-zA-Z][а-яА-ЯёЁ])";

        /// <inheritdoc />
        protected override void OnExecute(BuildContributorContext context, IList<ExtensibilityError> messages)
        {
            var prettyArguments = context.Arguments
                .Where(arg => !string.IsNullOrWhiteSpace(arg.Key))
                .ToDictionary(
                    arg => arg.Key.Trim(),
                    arg => arg.Value.Trim()
                );

            ObjectNamePatterns = NamingRuleParser.ParseContributorArguments(prettyArguments);
            prettyArguments.TryGetValue("Coding4fun.StringLiteral.InvalidPattern",
                out StringLiteralInvalidPattern);
        }
    }
}