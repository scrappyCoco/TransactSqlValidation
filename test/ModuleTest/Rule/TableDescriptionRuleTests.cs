using Coding4fun.TransactSql.Validations.Rules;
using Xunit;

namespace Coding4fun.TransactSql.ModuleTest.Rule
{
    public class TableDescriptionRuleTests : RuleTestBase<TableDescriptionRule>
    {
        [Fact]
        public void TableWithoutDescription() => TestInvalidCode();
    }
}