using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.Validations.Visitors
{
    public abstract class SqlVisitorBase : TSqlFragmentVisitor
    {
        private static readonly LinkedList<ValidationResult> EmptyList = new LinkedList<ValidationResult>();
        private LinkedList<ValidationResult> _validationResults;

        /// <summary>
        ///     Коллекция ошибок.
        /// </summary>
        public IEnumerable<ValidationResult> ValidationResults => _validationResults ?? EmptyList;

        /// <summary>
        ///     Добавление ошибки.
        /// </summary>
        /// <param name="resultCode">Код ошибки.</param>
        /// <param name="invalidFragment">Фрагмент кода, в котором произошла ошибка.</param>
        public void AddValidationResult(int resultCode, TSqlFragment invalidFragment)
        {
            if (_validationResults == null) _validationResults = new LinkedList<ValidationResult>();
            _validationResults.AddLast(new ValidationResult(invalidFragment, resultCode));
        }
    }
}