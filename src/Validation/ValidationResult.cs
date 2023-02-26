using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.Validations
{
    /// <summary>
    ///     Результат проверки Visitor'ом.
    /// </summary>
    public class ValidationResult
    {
        public ValidationResult(TSqlFragment invalidObject, int resultCode)
        {
            InvalidObject = invalidObject;
            ResultCode = resultCode;
        }

        /// <summary>
        ///     Объект, в котором обнаружилась ошибка.
        /// </summary>
        public TSqlFragment InvalidObject { get; }

        /// <summary>
        ///     Код ошибки.
        /// </summary>
        public int ResultCode { get; }

        /// <inheritdoc />
        public override string ToString() => $"{ResultCode} | {InvalidObject}";
    }
}