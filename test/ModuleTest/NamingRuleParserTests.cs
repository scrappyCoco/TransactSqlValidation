using System.Collections.Generic;
using System.IO;
using Coding4fun.TransactSql.Validations;
using Coding4fun.TransactSql.Validations.Extensions;
using Coding4fun.TransactSql.Validations.ValidationResults;
using Xunit;

namespace Coding4fun.TransactSql.ModuleTest
{
    public class NamingRuleParserTests
    {
        /// <summary>
        ///     Проверка парсера текстового файла.
        /// </summary>
        [Fact]
        public void ParseTest()
        {
            var rulesText = File.ReadAllText(@".\TestData\PrettyNamingRules.txt");

            var expectedRules =
                new Dictionary<ObjectNameValidationResult, string>
                {
                // @formatter:off
                [ObjectNameValidationResult.Table]                           = @"^(\[{Schema}\]\.\[MY_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]|\[import\].+)$",
                [ObjectNameValidationResult.Column]                          = @"^(\[{Schema}\]\.\[{Table}\]\.\[{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]|\[import\].+)$",
                [ObjectNameValidationResult.DefaultConstraint]               = @"^\[{Schema}\]\.\[{Table}\]\.\[{Column}\]\.\[DF_{Column}\]$",
                [ObjectNameValidationResult.PrimaryKeyConstraint]            = @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[PK_{Table}\]$",
                [ObjectNameValidationResult.UniqueConstraint]                = @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[UN_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$",
                [ObjectNameValidationResult.CheckConstraint]                 = @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[CH_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$",
                [ObjectNameValidationResult.BTreeNonUniqueClusteredIndex]    = @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$",
                [ObjectNameValidationResult.BTreeUniqueClusteredIndex]       = @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$",
                [ObjectNameValidationResult.BTreeNonUniqueNonClusteredIndex] = @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$",
                [ObjectNameValidationResult.BTreeUniqueNonClusteredIndex]    = @"^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$",
                [ObjectNameValidationResult.ClusteredColumnStoreIndex]       = @"^\[{Schema}\]\.\[{Table}\]\.\[CS_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$",
                [ObjectNameValidationResult.NonClusteredColumnStoreIndex]    = @"^\[{Schema}\]\.\[{Table}\]\.\[CS_{Table}_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$",
                [ObjectNameValidationResult.Procedure]                       = @"^\[{Schema}\]\.\[[A-Z][A-Za-z0-9]*?\]$",
                [ObjectNameValidationResult.RoutineParameter]                = @"^\[{Schema}\]\.\[[A-Z][A-Za-z0-9]*?\]\.\[@[A-Z][A-Za-z0-9]*?\]$",
                [ObjectNameValidationResult.Variable]                        = @"^\[{Schema}\]\.\[[A-Z][A-Za-z0-9]*?\]\.\[@[a-z][a-z0-9]*([A-Z]+[a-z0-9]+)*?\]$",
                [ObjectNameValidationResult.Function]                        = @"^\[{Schema}\]\.\[[A-Z][A-Za-z0-9]*?\]$"
                    // @formatter:on
                };

            var actualRules =
                new StringReader(rulesText).Using(NamingRuleParser.ParseTextFile);

            Assert.Equal(expectedRules, actualRules);
        }
    }
}