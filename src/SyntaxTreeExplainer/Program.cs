using System.IO;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Coding4fun.TransactSql.SyntaxTreeExplainer
{
    internal static class Program
    {
        public static void Main()
        {
            const string sql = @"DECLARE @v VARCHAR(MAX);";

            using (TextReader sqlTextReader = new StringReader(sql))
            {
                var parser = new TSql150Parser(true, SqlEngineType.All);
                var tree = parser.Parse(sqlTextReader, out var errors);
            }
        }
    }
}