using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Coding4Fun.TransactSql.Analyzers.Rules;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Xunit;

namespace Coding4Fun.TransactSql.ModuleTest;

public class RuleTests
{
    private const string TestDataRoot = @"TestData/Rule/";

    /// <summary>
    /// Searching for message with expected error message inside a test file.
    /// </summary>
    /// <example>-- Expected error message: SR1003 : Coding4Fun : Object name 'IX_FIRST_NAME' doesn't match the pattern: '^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[BTreeNonUniqueNonClustered_{Table}_{LATIN_UPPER_CASE}\]$'</example>
    private readonly Regex _expectedCommentRegex = new(@"-- Expected error message: (?<message>[^\r\n]+)",
        RegexOptions.Compiled | RegexOptions.Multiline);
    
    [Theory]
    [TestDirectory(TestDataRoot + nameof(NotDeterministicSelectRule))]
    public void TestNotDeterministicSelectRule(string fileName) => Test<NotDeterministicSelectRule>(fileName);
    
    [Theory]
    [TestDirectory(TestDataRoot + nameof(ObjectNameRule))]
    public void TestObjectNameRule(string fileName) => Test<ObjectNameRule>(fileName);
    
    [Theory]
    [TestDirectory(TestDataRoot + nameof(SchemaRequireRule))]
    public void TestSchemaRequireRule(string fileName) => Test<SchemaRequireRule>(fileName);
    
    [Theory]
    [TestDirectory(TestDataRoot + nameof(StringLiteralRule))]
    public void TestStringLiteralRule(string fileName) => Test<StringLiteralRule>(fileName);
    
    [Theory]
    [TestDirectory(TestDataRoot + nameof(TableDescriptionRule))]
    public void TestTableDescriptionRule(string fileName) => Test<TableDescriptionRule>(fileName);

    [Theory]
    [TestDirectory(TestDataRoot + nameof(VariableUsageRule))]
    public void TestVariableUsageRule(string fileName) => Test<VariableUsageRule>(fileName);
    
    private void Test<TRule>(string fileName)
        where TRule : SqlCodeAnalysisRule
    {
        string sqlFilePath = Path.Combine(TestDataRoot, @$"{typeof(TRule).Name}/{fileName}.sql");
        string sqlFileContent = File.ReadAllText(sqlFilePath);

        TSqlModel sqlModel = new TSqlModel(SqlServerVersion.Sql160, new TSqlModelOptions());
        TSqlObjectOptions sqlObjectOptions = new();
        sqlModel.AddOrUpdateObjects(sqlFileContent, fileName, sqlObjectOptions);
        sqlModel.AddOrUpdateObjects(
            File.ReadAllText(@"./TestData/SqlAnalysisConfiguration.sql"),
            "SqlAnalysisConfiguration",
            sqlObjectOptions);

        string testRuleId = typeof(TRule).GetCustomAttribute<ExportCodeAnalysisRuleAttribute>()!.Id;

        RuleConfiguration[] coding4FunRules = typeof(TRule).Assembly.GetExportedTypes()
            .Where(type => type.GetCustomAttribute<ExportCodeAnalysisRuleAttribute>() != null)
            .Select(rule => rule.GetCustomAttribute<ExportCodeAnalysisRuleAttribute>()!.Id)
            .Select(ruleId =>
                new RuleConfiguration(ruleId, enabled: ruleId == testRuleId, SqlRuleProblemSeverity.Error))
            .ToArray();

        CodeAnalysisResult codeAnalysisResult = new CodeAnalysisServiceFactory()
            .CreateAnalysisService(sqlModel, new CodeAnalysisServiceSettings
            {
                RuleSettings = new CodeAnalysisRuleSettings(coding4FunRules)
            })
            .Analyze(sqlModel);

        HashSet<string> actualErrorMessages = codeAnalysisResult.Problems
            .Select(problem => problem.ErrorMessageString)
            .ToHashSet(StringComparer.Ordinal);

        HashSet<string> expectedErrorMessages = _expectedCommentRegex.Matches(sqlFileContent)
            .Select(match => match.Groups["message"].Value.Trim())
            .ToHashSet();

        // We must define all expected error messages inside our test files.
        Assert.True(expectedErrorMessages.SetEquals(actualErrorMessages));
    }
}