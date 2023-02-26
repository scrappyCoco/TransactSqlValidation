using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.TransactSql.ScriptDom;

[assembly: AssemblyTitle("Coding4fun.SQL.Validations")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Coding4fun")]
[assembly: AssemblyProduct("TSqlValidation")]
[assembly: AssemblyCopyright("Copyright ©  2023")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("3de1c1b1-28fa-4195-a12b-4e68ff8ac618")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: DebuggerDisplay("[{Value}]", Target = typeof(Identifier))]
[assembly: DebuggerDisplay("[{ConstraintIdentifier.Value}]", Target = typeof(ConstraintDefinition))]
[assembly: DebuggerDisplay("[{Name.Value}]", Target = typeof(IndexDefinition))]