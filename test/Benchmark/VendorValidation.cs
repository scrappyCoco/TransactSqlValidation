using System.Collections.ObjectModel;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;

namespace Coding4fun.TransactSql.Benchmark
{
    /// <summary>
    ///     Замер производительности MS, YM, MS + YM.
    /// </summary>
    [SimpleJob(RunStrategy.Monitoring, 1, 1, 10, 1)]
    public class VendorValidation
    {
        /// <summary>
        ///     Копируется из ExampleSqlProject.sqlproj в Benchmark.csproj.
        /// </summary>
        private const string DacPackPath = @".\ExampleSqlProject.dacpac";

        /// <summary>
        ///     Включена группа встроенных правил Microsoft.
        /// </summary>
        private const string MsRules = "+!Microsoft.Rules.Data.SR0001;" +
                                       "+!Microsoft.Rules.Data.SR0004;" +
                                       "+!Microsoft.Rules.Data.SR0005;" +
                                       "+!Microsoft.Rules.Data.SR0007;" +
                                       "+!Microsoft.Rules.Data.SR0008;" +
                                       "+!Microsoft.Rules.Data.SR0009;" +
                                       "+!Microsoft.Rules.Data.SR0010;" +
                                       "+!Microsoft.Rules.Data.SR0011;" +
                                       "+!Microsoft.Rules.Data.SR0012;" +
                                       "+!Microsoft.Rules.Data.SR0013;" +
                                       "+!Microsoft.Rules.Data.SR0014;" +
                                       "+!Microsoft.Rules.Data.SR0016;" +
                                       "-!Coding4fun.SR1001;" +
                                       "-!Coding4fun.SR1002;" +
                                       "-!Coding4fun.SR1003;" +
                                       "-!Coding4fun.SR1004;" +
                                       "-!Coding4fun.SR1005;";

        /// <summary>
        ///     Включена группа правил Coding4fun.
        /// </summary>
        private const string C4FRules = "-!Microsoft.Rules.Data.SR0001;" +
                                        "-!Microsoft.Rules.Data.SR0004;" +
                                        "-!Microsoft.Rules.Data.SR0005;" +
                                        "-!Microsoft.Rules.Data.SR0007;" +
                                        "-!Microsoft.Rules.Data.SR0008;" +
                                        "-!Microsoft.Rules.Data.SR0009;" +
                                        "-!Microsoft.Rules.Data.SR0010;" +
                                        "-!Microsoft.Rules.Data.SR0011;" +
                                        "-!Microsoft.Rules.Data.SR0012;" +
                                        "-!Microsoft.Rules.Data.SR0013;" +
                                        "-!Microsoft.Rules.Data.SR0014;" +
                                        "-!Microsoft.Rules.Data.SR0016;" +
                                        "+!Coding4fun.SR1001;" +
                                        "+!Coding4fun.SR1002;" +
                                        "+!Coding4fun.SR1003;" +
                                        "+!Coding4fun.SR1004;" +
                                        "+!Coding4fun.SR1005;";

        /// <summary>
        ///     Включены все правила.
        /// </summary>
        private const string AllRules = "+!Microsoft.Rules.Data.SR0001;" +
                                        "+!Microsoft.Rules.Data.SR0004;" +
                                        "+!Microsoft.Rules.Data.SR0005;" +
                                        "+!Microsoft.Rules.Data.SR0007;" +
                                        "+!Microsoft.Rules.Data.SR0008;" +
                                        "+!Microsoft.Rules.Data.SR0009;" +
                                        "+!Microsoft.Rules.Data.SR0010;" +
                                        "+!Microsoft.Rules.Data.SR0011;" +
                                        "+!Microsoft.Rules.Data.SR0012;" +
                                        "+!Microsoft.Rules.Data.SR0013;" +
                                        "+!Microsoft.Rules.Data.SR0014;" +
                                        "+!Microsoft.Rules.Data.SR0016;" +
                                        "+!Coding4fun.SR1001;" +
                                        "+!Coding4fun.SR1002;" +
                                        "+!Coding4fun.SR1003;" +
                                        "+!Coding4fun.SR1004;" +
                                        "+!Coding4fun.SR1005;";


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
        [Params(MsRules, C4FRules, AllRules)]
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnassignedField.Global
        public string Rules;

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
            var codeAnalysisRuleSettings =
                CodeAnalysisRuleSettings.CreateFromSettingsString(Rules, out _);

            _codeAnalysisService = new CodeAnalysisServiceFactory().CreateAnalysisService(_model,
                new CodeAnalysisServiceSettings { RuleSettings = codeAnalysisRuleSettings });
        }

        /// <summary>
        ///     Производим замер призводительности группы правил.
        /// </summary>
        [Benchmark]
        public ReadOnlyCollection<SqlRuleProblem> Analyze() => _codeAnalysisService.Analyze(_model).Problems;
    }
}