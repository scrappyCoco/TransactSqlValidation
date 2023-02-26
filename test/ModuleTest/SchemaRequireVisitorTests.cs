using Coding4fun.TransactSql.Validations.ValidationResults;
using Coding4fun.TransactSql.Validations.Visitors;
using Xunit;

namespace Coding4fun.TransactSql.ModuleTest
{
    public class SchemaRequireVisitorTests : VisitorTestBase<SchemaRequireVisitor>
    {
        [Theory]
        [InlineData("CteDoesNotThrow")]
        [InlineData("TempTableDoseNotThrow")]
        [InlineData("IdentifierWithSchemaDoesNotThrow")]
        [InlineData("InsideCteDoesNotThrow")]
        [InlineData("UpdateAliasDoesNotThrow")]
        [InlineData("DeleteAliasDoesNotThrow")]
        [InlineData("InsertIntoTableDoesNotThrow")]
        public void SuccessValidations(string fileName) => new TestBuilder(fileName).AssertDoesNotHaveErrors();

        // @formatter:off
        [Theory]
        [InlineData("UpdateTableThrows",      "MY_TABLE")]
        [InlineData("InsertIntoTableThrows",  "MY_TABLE")]
        [InlineData("DeleteTableThrows",      "MY_TABLE")]
        [InlineData("SingleIdentifierThrows", "MY_TABLE")]
        // @formatter:on
        public void ThrowValidations(string fileName, string identifierWithProblem) => new TestBuilder(fileName)
            .AssertHasError((int)SchemaRequireValidationResult.InvalidPath, identifierWithProblem);
    }
}