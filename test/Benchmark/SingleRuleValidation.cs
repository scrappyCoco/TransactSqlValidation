using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;

namespace Coding4fun.TransactSql.Benchmark
{
    /// <summary>
    ///     Замер производительности каждого Validation отдельно.
    /// </summary>
    [SimpleJob(RunStrategy.Monitoring, 1, 1, 10, 1)]
    public class SingleRuleValidation
    {
        /// <summary>
        ///     Копируется из ExampleSqlProject.sqlproj в Benchmark.csproj.
        /// </summary>
        private const string DacPackPath = @".\ExampleSqlProject.dacpac";

        /// <summary>
        ///     Сервис анализа кода Transact SQL.
        /// </summary>
        private CodeAnalysisService _codeAnalysisService;

        /// <summary>
        ///     Модель проекта, загруженная из dacpac.
        /// </summary>
        private TSqlModel _model;


        /// <summary>
        ///     Id правила, по которому происходит замер производительности.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnassignedField.Global
        [ParamsSource(nameof(GetRules))] public string RuleId;

        /// <summary>
        ///     Список павил проверки кода, по которым делаем замеры производительности.
        /// </summary>
        public static IEnumerable<string> GetRules() => new[]
        {
            "!Microsoft.Rules.Data.SR0001",
            "!Microsoft.Rules.Data.SR0004",
            "!Microsoft.Rules.Data.SR0005",
            "!Microsoft.Rules.Data.SR0007",
            "!Microsoft.Rules.Data.SR0008",
            "!Microsoft.Rules.Data.SR0009",
            "!Microsoft.Rules.Data.SR0010",
            "!Microsoft.Rules.Data.SR0011",
            "!Microsoft.Rules.Data.SR0012",
            "!Microsoft.Rules.Data.SR0013",
            "!Microsoft.Rules.Data.SR0014",
            "!Microsoft.Rules.Data.SR0016",
            "!Coding4fun.SR1001",
            "!Coding4fun.SR1002",
            "!Coding4fun.SR1003",
            "!Coding4fun.SR1004",
            "!Coding4fun.SR1005"
        };

        /// <summary>
        ///     Загрузка модели из dacpac, что бы это не попадала во время анализа кода.
        /// </summary>
        [GlobalSetup]
        public void SetupGlobal()
        {
            _model = TSqlModel.LoadFromDacpac(DacPackPath, new ModelLoadOptions
            {
                LoadAsScriptBackedModel = true
            });
        }

        [IterationSetup]
        public void SetupIteration()
        {
            // Осталвяем включенным только одно правило.
            var rules = string.Join(";", GetRules().Select(rId => (rId == RuleId ? "+" : "-") + rId));

            var codeAnalysisRuleSettings =
                CodeAnalysisRuleSettings.CreateFromSettingsString(rules, out _);

            _codeAnalysisService = new CodeAnalysisServiceFactory().CreateAnalysisService(_model,
                new CodeAnalysisServiceSettings { RuleSettings = codeAnalysisRuleSettings });
        }

        /// <summary>
        ///     Производим замер призводительности одного правила.
        /// </summary>
        [Benchmark]
        public ReadOnlyCollection<SqlRuleProblem> Analyze() => _codeAnalysisService.Analyze(_model).Problems;
    }
}