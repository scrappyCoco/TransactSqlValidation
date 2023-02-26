using System.Collections.Generic;
using System.Linq;
using Coding4fun.TransactSql.Validations.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;

namespace Coding4fun.TransactSql.Validations.Rules
{
    public abstract class SqlCodeAnalysisRuleBase<TSqlRuleVisitor> : SqlCodeAnalysisRule
        where TSqlRuleVisitor : SqlVisitorBase, new()
    {
        private static readonly List<SqlRuleProblem> WithoutErrors = new List<SqlRuleProblem>(0);

        /// <inheritdoc />
        public sealed override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            if (ruleExecutionContext.ScriptFragment == null) return WithoutErrors;
            var visitor = new TSqlRuleVisitor();
            InitializeVisitor(visitor, ruleExecutionContext);
            ruleExecutionContext.ScriptFragment.Accept(visitor);
            if (!visitor.ValidationResults.Any()) return WithoutErrors;

            IList<SqlRuleProblem> problems = visitor.ValidationResults
                .Select(validationResult => new SqlRuleProblem(
                    GetWarningDescription(validationResult),
                    ruleExecutionContext.ModelElement,
                    validationResult.InvalidObject))
                .ToList();

            return problems;
        }

        /// <summary>
        ///     Инициализация <paramref name="visitor" />.
        /// </summary>
        /// <param name="visitor">Посетитель.</param>
        /// <param name="ruleExecutionContext">Контекст правила.</param>
        protected virtual void InitializeVisitor(TSqlRuleVisitor visitor, SqlRuleExecutionContext ruleExecutionContext)
        {
        }

        /// <summary>
        ///     Получение текста сообщения, которое отобразится в Visual Studio.
        /// </summary>
        /// <param name="validationResult">Результат валидации, полученный из Visitor.</param>
        /// <returns>Описание ошибки, которое увидит пользователь в Visual Studio.</returns>
        protected abstract string GetWarningDescription(ValidationResult validationResult);
    }
}