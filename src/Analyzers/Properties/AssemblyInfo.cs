using System.Diagnostics;
using Microsoft.SqlServer.TransactSql.ScriptDom;

[assembly: DebuggerDisplay("[{Value}]", Target = typeof(Identifier))]
[assembly: DebuggerDisplay("[{ConstraintIdentifier.Value}]", Target = typeof(ConstraintDefinition))]
[assembly: DebuggerDisplay("[{Name.Value}]", Target = typeof(IndexDefinition))]