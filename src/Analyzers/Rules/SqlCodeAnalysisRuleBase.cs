using System.Collections.Generic;
using System.IO;
using System.Linq;
using Coding4Fun.TransactSql.Analyzers.Configuration;
using Coding4Fun.TransactSql.Analyzers.Extensions;
using Coding4Fun.TransactSql.Analyzers.Visitors;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4Fun.TransactSql.Analyzers.Rules;

/// <summary>
/// Base class for TSQL validation rule.
/// </summary>
/// <typeparam name="TSqlRuleVisitor">Visitor, that inspects a syntax tree and finds code smells.</typeparam>
public abstract class SqlCodeAnalysisRuleBase<TSqlRuleVisitor> : SqlCodeAnalysisRule
    where TSqlRuleVisitor : SqlVisitorBase, new()
{
    private readonly List<SqlRuleProblem> _withoutErrors = [];
    private bool _isConfigurationInitialized;

    /// <summary>
    /// Configuration for code analysis.
    /// </summary>
    protected SqlAnalysisConfiguration? SqlAnalysisConfiguration { get; private set; }

    private void InitializeConfiguration(TSqlModel sqlModel)
    {
        if (_isConfigurationInitialized) return;
        
        // Configuration holds in the procedure dbo.SqlAnalysisConfiguration inside string literal.
        // Example:
        //
        // CREATE PROCEDURE [dbo].[SqlAnalysisConfiguration]
        // AS
        // BEGIN
        //     DECLARE @config NVARCHAR(MAX) = N'
        // Coding4fun.ObjectName.LATIN_UPPER_CASE                = [A-Z][A-Z0-9_]+?;
        // Coding4fun.ObjectName.latin_lower_case                = [a-z][a-z0-9_]+?;
        // Coding4fun.ObjectName.LatinPascalCase                 = [A-Z][A-Za-z0-9]+?;
        // Coding4fun.ObjectName.latinCamelCase                  = [a-z][A-Za-z0-9]+?;
        // Coding4fun.ObjectName.Table                           = ^\[{Schema}\]\.\[P_{LATIN_UPPER_CASE}_S\]$;
        // ... and so on.';
        const string procedureWithConfiguration = "SqlAnalysisConfiguration";
        TSqlObject? procedureWithEditorConfig = sqlModel.GetObject(ModelSchema.Procedure,
            new ObjectIdentifier("dbo", procedureWithConfiguration), DacQueryScopes.All);

        if (procedureWithConfiguration != null)
        {
            string sql = procedureWithEditorConfig.GetScript();
            using StringReader stringReader = new(sql);
            TSqlFragment createProcedureFragment = TSqlParser
                .CreateParser(SqlVersion.Sql160, true)
                .Parse(stringReader, out _);
            
            SearchElementVisitor<StringLiteral> searchElementVisitor = new();
            createProcedureFragment.Accept(searchElementVisitor);
            string configurationText = searchElementVisitor.FoundElements.FirstOrDefault()?.Value
                                       ?? throw new SqlValidationException(
                                           $"Procedure {procedureWithConfiguration} does not contain string literal with configuration");

            SqlAnalysisConfiguration = new StringReader(configurationText).Using(ConfigurationParser.Parse);            
        }

        _isConfigurationInitialized = true;
    }

    /// <inheritdoc />
    public sealed override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
    {
        InitializeConfiguration(ruleExecutionContext.SchemaModel);

        if (ruleExecutionContext.ScriptFragment == null) return _withoutErrors;
        TSqlRuleVisitor visitor = new();
        InitializeVisitor(visitor, ruleExecutionContext);
        ruleExecutionContext.ScriptFragment.Accept(visitor);
        if (!visitor.ValidationResults.Any()) return _withoutErrors;

        IList<SqlRuleProblem> problems = visitor.ValidationResults
            .Select(validationResult => new SqlRuleProblem(
                GetWarningDescription(validationResult),
                ruleExecutionContext.ModelElement,
                validationResult.InvalidObject))
            .ToList();

        return problems;
    }

    /// <summary>
    /// Initialize <paramref name="visitor" />.
    /// </summary>
    /// <param name="visitor">TSQL visitor, which finds code smells.</param>
    /// <param name="ruleExecutionContext">Rule execution context.</param>
    protected virtual void InitializeVisitor(TSqlRuleVisitor visitor, SqlRuleExecutionContext ruleExecutionContext)
    {
    }

    /// <summary>
    /// Getting a message, that will be displayed in the IDE.
    /// </summary>
    /// <param name="validationResult">The validation result, that was gotten from the Visitor.</param>
    /// <returns>A message, that will be displayed in the IDE.</returns>
    protected abstract string GetWarningDescription(ValidationResult validationResult);
}