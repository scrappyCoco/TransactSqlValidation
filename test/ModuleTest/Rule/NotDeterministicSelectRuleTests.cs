using Coding4Fun.TransactSql.Analyzers.Rules;
using Xunit;

namespace Coding4Fun.TransactSql.ModuleTest.Rule;

public class NotDeterministicSelectRuleTests : RuleTestBase<NotDeterministicSelectRule>
{
    [Theory]
    [TestDirectory(@$".\TestData\Rule\{nameof(NotDeterministicSelectRule)}")]
    public void File(string testFileName) => TestFile(testFileName);
}