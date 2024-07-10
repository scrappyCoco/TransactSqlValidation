using Coding4Fun.TransactSql.Analyzers.Rules;
using Xunit;

namespace Coding4Fun.TransactSql.ModuleTest.Rule;

public class SchemaRequireRuleTests : RuleTestBase<SchemaRequireRule>
{
    [Theory]
    [TestDirectory(@$".\TestData\Rule\{nameof(SchemaRequireRule)}")]
    public void File(string testFileName) => TestFile(testFileName);
}