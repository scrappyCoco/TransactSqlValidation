using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Coding4fun.TransactSql.Validations;
using Coding4fun.TransactSql.Validations.Extensions;
using Coding4fun.TransactSql.Validations.Visitors;
using Xunit;
using Result = Coding4fun.TransactSql.Validations.ValidationResults.ObjectNameValidationResult;

namespace Coding4fun.TransactSql.ModuleTest
{
    public class ObjectNameVisitorTests : VisitorTestBase<ObjectNameVisitor>
    {
        private readonly Dictionary<Result, string> _namingRules;

        public ObjectNameVisitorTests() => _namingRules = new StreamReader(@".\TestData\VariousNamingRules.txt")
            .Using(NamingRuleParser.ParseTextFile);

        [Fact]
        public void AbsoluteValid() => new TestBuilder()
            .Initialize(visitor => SetNamingRules(visitor))
            .AssertDoesNotHaveErrors();

        // @formatter:off
        [Theory]
        [InlineData(Result.Table,                           "MY_TABLE")]
        [InlineData(Result.Column,                          "_MY_TABLE_COLUMN")]
        [InlineData(Result.PrimaryKeyConstraint,            "MY_TABLE_PK")]
        [InlineData(Result.UniqueConstraint,                "MY_TABLE_SUFFIX_UN")]
        [InlineData(Result.DefaultConstraint,               "MY_TABLE_ID_3_DF")]
        [InlineData(Result.BTreeNonUniqueClusteredIndex,    "MY_TABLE_SUFFIX_IXNUC")]
        [InlineData(Result.BTreeUniqueClusteredIndex,       "MY_TABLE_SUFFIX_IXUC")]
        [InlineData(Result.BTreeNonUniqueNonClusteredIndex, "MY_TABLE_SUFFIX_IXNUNC")]
        [InlineData(Result.BTreeUniqueNonClusteredIndex,    "MY_TABLE_SUFFIX_IXUNC")]
        [InlineData(Result.ClusteredColumnStoreIndex,       "MY_TABLE_SUFFIX_CSC")]
        [InlineData(Result.NonClusteredColumnStoreIndex,    "MY_TABLE_SUFFIX_CSNC")]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        // @formatter:on
        public void Invalid(Result expectedResult, string identifierWithProblem) => new TestBuilder()
            .Initialize(visitor => SetNamingRules(visitor, expectedResult))
            .AssertHasError((int)expectedResult, identifierWithProblem);

        // [Fact]
        // public void IgnoredObjectsDoNotThrow() => DoesNotHaveErrors(visitor => visitor.AddIgnoreNames(new[] { @"^\[import\].+" }));

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        private void SetNamingRules(ObjectNameVisitor visitor, Result? expectedResult = null)
        {
            var expectedResults = expectedResult != null
                ? new[] { expectedResult.Value }
                : (Result[])Enum.GetValues(typeof(Result));

            var expectedResultMap = expectedResults
                .Where(r => _namingRules.ContainsKey(r))
                .ToDictionary(r => r, r => _namingRules[r]);

            visitor.AddNamingRules(expectedResultMap);
        }
    }
}