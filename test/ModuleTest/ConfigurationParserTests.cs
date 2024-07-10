using System.IO;
using System.Linq;
using Coding4Fun.TransactSql.Analyzers;
using Coding4Fun.TransactSql.Analyzers.Configuration;
using Coding4Fun.TransactSql.Analyzers.Extensions;
using Coding4Fun.TransactSql.Analyzers.ValidationResults;
using Xunit;

namespace Coding4Fun.TransactSql.ModuleTest;

public class ConfigurationParserTests
{
    [Fact]
    public void ParseNamingTest()
    {
        NamingRule[] expectedNamingRules =
        [ // @formatter:off
            new(ObjectNameValidationResult.Table,                           OriginalPattern: @"^(\[{Schema}\]\.\[MY_{LATIN_UPPER_CASE}\]|\[import\].+)$",                        CompiledPattern: @"^(\[{Schema}\]\.\[MY_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]|\[import\].+)$"),
            new(ObjectNameValidationResult.Column,                          OriginalPattern: @"^(\[{Schema}\]\.\[{Table}\]\.\[{Table}_{LATIN_UPPER_CASE}\]|\[import\].+)$",      CompiledPattern: @"^(\[{Schema}\]\.\[{Table}\]\.\[{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]|\[import\].+)$"),
            new(ObjectNameValidationResult.DefaultConstraint,               OriginalPattern: @"^\[{Schema}\]\.\[{Table}\]\.\[{Column}\]\.\[DF_{Column}\]$",                      CompiledPattern: @"^\[{Schema}\]\.\[{Table}\]\.\[{Column}\]\.\[DF_{Column}\]$"),
            new(ObjectNameValidationResult.PrimaryKeyConstraint,            OriginalPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[PK_{Table}\]$",                    CompiledPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[PK_{Table}\]$"),
            new(ObjectNameValidationResult.UniqueConstraint,                OriginalPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[UN_{Table}_{LATIN_UPPER_CASE}\]$", CompiledPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[UN_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$"),
            new(ObjectNameValidationResult.CheckConstraint,                 OriginalPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[CH_{Table}_{LATIN_UPPER_CASE}\]$", CompiledPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[CH_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$"),
            new(ObjectNameValidationResult.BTreeNonUniqueClusteredIndex,    OriginalPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$", CompiledPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$"),
            new(ObjectNameValidationResult.BTreeUniqueClusteredIndex,       OriginalPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$", CompiledPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$"),
            new(ObjectNameValidationResult.BTreeNonUniqueNonClusteredIndex, OriginalPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$", CompiledPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$"),
            new(ObjectNameValidationResult.BTreeUniqueNonClusteredIndex,    OriginalPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$", CompiledPattern: @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$"),
            new(ObjectNameValidationResult.ClusteredColumnStoreIndex,       OriginalPattern: @"^\[{Schema}\]\.\[{Table}\]\.\[CS_{Table}_{LATIN_UPPER_CASE}\]$",                  CompiledPattern: @"^\[{Schema}\]\.\[{Table}\]\.\[CS_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$"),
            new(ObjectNameValidationResult.NonClusteredColumnStoreIndex,    OriginalPattern: @"^\[{Schema}\]\.\[{Table}\]\.\[CS_{Table}_{LATIN_UPPER_CASE}\]$",                  CompiledPattern: @"^\[{Schema}\]\.\[{Table}\]\.\[CS_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$"),
            new(ObjectNameValidationResult.Procedure,                       OriginalPattern: @"^\[{Schema}\]\.\[{LatinPascalCase}\]$",                                           CompiledPattern: @"^\[{Schema}\]\.\[[A-Z][A-Za-z0-9]*?\]$"),
            new(ObjectNameValidationResult.RoutineParameter,                OriginalPattern: @"^\[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{LatinPascalCase}\]$",                   CompiledPattern: @"^\[{Schema}\]\.\[[A-Z][A-Za-z0-9]*?\]\.\[@[A-Z][A-Za-z0-9]*?\]$"),
            new(ObjectNameValidationResult.Variable,                        OriginalPattern: @"^\[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{latinCamelCase}\]$",                    CompiledPattern: @"^\[{Schema}\]\.\[[A-Z][A-Za-z0-9]*?\]\.\[@[a-z][a-z0-9]*([A-Z]+[a-z0-9]+)*?\]$"),
            new(ObjectNameValidationResult.Function,                        OriginalPattern: @"^\[{Schema}\]\.\[{LatinPascalCase}\]$",                                           CompiledPattern: @"^\[{Schema}\]\.\[[A-Z][A-Za-z0-9]*?\]$")
            // @formatter:on
        ];
        const string expectedInvalidWordMixPattern = "([а-яА-ЯёЁ][a-zA-Z])|([a-zA-Z][а-яА-ЯёЁ])";

        SqlAnalysisConfiguration sqlAnalysisConfiguration = File.ReadAllText(@".\TestData\PrettyNamingRules.txt")
            .Let(rules => new StringReader(rules))
            .Using(ConfigurationParser.Parse);

        NamingRule[] actualRules = sqlAnalysisConfiguration
            .Naming!
            .Select(rule => rule.Value)
            .ToArray();

        Assert.Equal(expectedNamingRules, actualRules);
        Assert.Equal(expectedInvalidWordMixPattern, sqlAnalysisConfiguration.InvalidWordMixPattern!.ToString());
    }
}