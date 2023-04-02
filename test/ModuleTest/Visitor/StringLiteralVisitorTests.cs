using Coding4fun.TransactSql.Validations.Visitors;
using Xunit;

namespace Coding4fun.TransactSql.ModuleTest.Visitor
{
    public class StringLiteralVisitorTests : VisitorTestBase<StringLiteralVisitor>
    {
        /// <summary>
        ///     В InlineData необходимо указывать название файла в папке TestData/CyrillicLatinMixVisitor,
        ///     который не должен содержать ошибок при проверке StringLiteralVisitor.
        /// </summary>
        /// <param name="fileName">Название файла в папке TestData/StringLiteralVisitor/{fileName}.sql.</param>
        [Theory]
        [InlineData("CyrillicOnlyDoesNotThrow")]
        [InlineData("LatinOnlyDoesNotThrow")]
        [InlineData("SeparateWordsAreAllowed")]
        public void SuccessValidations(string fileName) => new TestBuilder(fileName)
            .Initialize(SetPattern)
            .AssertDoesNotHaveErrors();

        /// <summary>
        ///     Сочетание кириллицы и латиницы порождает ошибку при валидации.
        ///     Файл: TestData/StringLiteralVisitor/MixThrows.sql
        /// </summary>
        [Fact]
        public void MixThrows() => new TestBuilder()
            .Initialize(SetPattern)
            .AssertHasError(0, "КириллицаLatin");

        /// <summary>
        ///     Принудительное игнорирование сочетания кириллицы и латины в слове "ThisIsInvalidЗначение".
        /// </summary>
        [Fact]
        public void IgnoredWordsDoesNotThrow() => new TestBuilder()
            .Initialize(SetPattern)
            .Initialize(visitor => visitor.AddIgnoredWords(new[] { "ThisIsInvalidЗначение" }))
            .AssertDoesNotHaveErrors();

        private static void SetPattern(StringLiteralVisitor visitor)
        {
            // Нельзя сочетать кириллицу и латиницу в одном слове.
            visitor.SetPattern("([а-яА-ЯёЁ][a-zA-Z])|([a-zA-Z][а-яА-ЯёЁ])");
        }
    }
}