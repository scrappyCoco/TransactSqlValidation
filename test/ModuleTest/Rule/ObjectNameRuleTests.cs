using Coding4Fun.TransactSql.Analyzers.Rules;
using Xunit;

namespace Coding4Fun.TransactSql.ModuleTest.Rule;

public class ObjectNameRuleTests : RuleTestBase<ObjectNameRule>
{
    [Theory]
    [TestDirectory(@$".\TestData\Rule\{nameof(ObjectNameRule)}")]
    public void File(string testFileName) => TestFile(testFileName);
}