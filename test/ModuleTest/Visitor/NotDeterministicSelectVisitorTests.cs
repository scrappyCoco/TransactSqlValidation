using Coding4fun.TransactSql.Validations.Visitors;
using Xunit;

namespace Coding4fun.TransactSql.ModuleTest.Visitor
{
    public class NotDeterministicSelectVisitorTests : VisitorTestBase<NotDeterministicSelectVisitor>
    {
        [Theory]
        [InlineData("TopWithOrderByDoesNotThrow")]
        [InlineData("TopWithoutOrderByInsideExistsDoesNotThrow")]
        public void SuccessValidations(string fileName) => new TestBuilder(fileName).AssertDoesNotHaveErrors();

        [Fact]
        public void TopWithoutOrderByThrows() => new TestBuilder().AssertHasError(0, "TOP (1)");
    }
}