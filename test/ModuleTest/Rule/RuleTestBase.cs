using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Xunit;

namespace Coding4Fun.TransactSql.ModuleTest.Rule;

public abstract class RuleTestBase<TRule> where TRule : SqlCodeAnalysisRule, new()
{
    private readonly Regex _expectedCommentRegex = new(@"-- Expected error message: (?<message>[^\r\n]+)",
        RegexOptions.Compiled | RegexOptions.Multiline);

    protected void TestInvalidCode([CallerMemberName] string methodName = null)
    {
        HashSet<string> actualErrorMessages = GetErrorMessages(methodName, out string sqlFileContent);

        HashSet<string> expectedErrorMessages = _expectedCommentRegex.Matches(sqlFileContent)
            .Select(match => match.Groups["message"].Value.Trim())
            .ToHashSet();

        Assert.True(expectedErrorMessages.SetEquals(actualErrorMessages));
    }
    
    protected void TestFile(string testFileName)
    {
        HashSet<string> actualErrorMessages = GetErrorMessages(Path.GetFileNameWithoutExtension(testFileName), out string sqlFileContent);

        HashSet<string> expectedErrorMessages = _expectedCommentRegex.Matches(sqlFileContent)
            .Select(match => match.Groups["message"].Value.Trim())
            .ToHashSet();

        Assert.True(expectedErrorMessages.SetEquals(actualErrorMessages), "Expected error messages differ with actual.");
    }

    protected void TestValidCode([CallerMemberName] string methodName = null)
    {
        HashSet<string> actualErrorMessages = GetErrorMessages(methodName, out string sqlFileContent);
        Assert.Empty(actualErrorMessages);
    }

    private HashSet<string> GetErrorMessages(string methodName, out string sqlFileContent)
    {
        string sqlFilePath = @$".\TestData\Rule\{typeof(TRule).Name}\{methodName}.sql";
        sqlFileContent = File.ReadAllText(sqlFilePath);

        TSqlModel sqlModel = new TSqlModel(SqlServerVersion.Sql160, new TSqlModelOptions());
        TSqlObjectOptions sqlObjectOptions = new();
        sqlModel.AddOrUpdateObjects(sqlFileContent, methodName, sqlObjectOptions);
        sqlModel.AddOrUpdateObjects(
            File.ReadAllText(@".\TestData\SqlAnalysisConfiguration.sql"),
            "SqlAnalysisConfiguration",
            sqlObjectOptions);

        string testRuleId = typeof(TRule).GetCustomAttribute<ExportCodeAnalysisRuleAttribute>()!.Id;

        RuleConfiguration[] coding4FunRules = typeof(TRule).Assembly.GetExportedTypes()
            .Where(type => type.GetCustomAttribute<ExportCodeAnalysisRuleAttribute>() != null)
            .Select(rule => rule.GetCustomAttribute<ExportCodeAnalysisRuleAttribute>().Id)
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

        return actualErrorMessages;
    }
}