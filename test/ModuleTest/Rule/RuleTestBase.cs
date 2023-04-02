using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Dac.CodeAnalysis;
using Microsoft.SqlServer.Dac.Model;
using Xunit;

namespace Coding4fun.TransactSql.ModuleTest.Rule
{
    public abstract class RuleTestBase<TRule> where TRule : SqlCodeAnalysisRule
    {
        private readonly Regex _expectedCommentRegex = new Regex(@"-- Expected error message: (?<message>[^\r\n]+)",
            RegexOptions.Compiled | RegexOptions.Multiline);

        protected void TestInvalidCode([CallerMemberName] string methodName = null)
        {
            HashSet<string> actualErrorMessages = GetErrorMessages(methodName, out string sqlFileContent);

            HashSet<string> expectedErrorMessages = _expectedCommentRegex.Matches(sqlFileContent)
                .Cast<Match>()
                .Select(match => match.Groups["message"].Value)
                .ToHashSet();

            Assert.True(expectedErrorMessages.SetEquals(actualErrorMessages));
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

            TSqlModel sqlModel = new TSqlModel(SqlServerVersion.Sql150, new TSqlModelOptions());
            sqlModel.AddOrUpdateObjects(sqlFileContent, methodName, new TSqlObjectOptions());

            CodeAnalysisResult codeAnalysisResult = new CodeAnalysisServiceFactory()
                .CreateAnalysisService(sqlModel)
                .Analyze(sqlModel);

            HashSet<string> actualErrorMessages = codeAnalysisResult.Problems
                .Select(problem => problem.ErrorMessageString)
                .ToHashSet(StringComparer.Ordinal);

            return actualErrorMessages;
        }
    }
}