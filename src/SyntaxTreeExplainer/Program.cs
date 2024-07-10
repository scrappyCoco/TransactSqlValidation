using Microsoft.SqlServer.TransactSql.ScriptDom;

// Place there SQL for which you want to explain the syntax tree.
const string sql = @"SELECT TOP (1) *
FROM #T";
using StringReader sqlTextReader = new(sql);
TSql160Parser parser = new(true, SqlEngineType.All);
TSqlFragment? tree = parser.Parse(sqlTextReader, out IList<ParseError>? errors);
Console.WriteLine("Set up a breakpoint on this line to inspect a syntax tree or errors.");