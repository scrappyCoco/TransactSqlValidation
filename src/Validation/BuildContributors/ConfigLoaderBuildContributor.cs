using System.Collections.Generic;
using System.IO;
using System.Linq;
using Coding4fun.TransactSql.Validations.Extensions;
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

        static ConfigLoaderBuildContributor()
        {
            string defaultConfig = @"
Coding4fun.ObjectName.LATIN_UPPER_CASE                    = [A-Z][A-Z0-9]*(_[A-Z0-9])*?;
Coding4fun.ObjectName.latin_lower_case                    = [a-z][a-z0-9]*(_[a-z0-9])*?;
Coding4fun.ObjectName.LatinPascalCase                     = [A-Z][A-Za-z0-9]*?;
Coding4fun.ObjectName.latinCamelCase                      = [a-z][a-z0-9]*([A-Z]+[a-z0-9]+)*?;
Coding4fun.ObjectName.Table                               = ^(\[{Schema}\]\.\[MY_{LATIN_UPPER_CASE}\]|\[import\].+)$;
Coding4fun.ObjectName.Column                              = ^(\[{Schema}\]\.\[{Table}\]\.\[{Table}_{LATIN_UPPER_CASE}\]|\[import\].+)$;
Coding4fun.ObjectName.DefaultConstraint                   = ^\[{Schema}\]\.\[{Table}\]\.\[{Column}\]\.\[DF_{Column}\]$;
Coding4fun.ObjectName.PrimaryKeyConstraint                = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[PK_{Table}\]$;
Coding4fun.ObjectName.UniqueConstraint                    = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[UN_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.CheckConstraint                     = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[CH_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.BTreeNonUniqueClusteredIndex        = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.BTreeUniqueClusteredIndex           = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.BTreeNonUniqueNonClusteredIndex     = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.BTreeUniqueNonClusteredIndex        = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.ClusteredColumnStoreIndex           = ^\[{Schema}\]\.\[{Table}\]\.\[CS_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.NonClusteredColumnStoreIndex        = ^\[{Schema}\]\.\[{Table}\]\.\[CS_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.Procedure                           = ^\[{Schema}\]\.\[{LatinPascalCase}\]$;
Coding4fun.ObjectName.RoutineParameter                    = ^\[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{LatinPascalCase}\]$;
Coding4fun.ObjectName.Variable                            = ^\[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{latinCamelCase}\]$;
Coding4fun.ObjectName.Function                            = ^\[{Schema}\]\.\[{LatinPascalCase}\]$;";
            
            ObjectNamePatterns = new StringReader(defaultConfig).Using(NamingRuleParser.ParseTextFile);
        }

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