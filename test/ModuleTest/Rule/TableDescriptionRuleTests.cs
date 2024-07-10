﻿using Coding4Fun.TransactSql.Analyzers.Rules;
using Xunit;

namespace Coding4Fun.TransactSql.ModuleTest.Rule;

public class TableDescriptionRuleTests : RuleTestBase<TableDescriptionRule>
{
    [Theory]
    [TestDirectory(@$".\TestData\Rule\{nameof(TableDescriptionRule)}")]
    public void File(string testFileName) => TestFile(testFileName);
}