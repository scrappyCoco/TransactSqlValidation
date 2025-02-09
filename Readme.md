# Coding4Fun.TransactSql.Analyzers

This is an example of writing and using TSQL-analyzers, that can be attached through NuGet Repository. 
It is available only for sqlproj with [SDK-style](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/overview).

Example of a modern sqlproj with SDK-style:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project DefaultTargets="Build">
   <Sdk Name="Microsoft.Build.Sql" Version="1.0.0-rc1"/>
    <PropertyGroup>
        <Name>ExampleSqlProject</Name>
        <DSP>Microsoft.Data.Tools.Schema.Sql.Sql160DatabaseSchemaProvider</DSP>
        <ModelCollation>1033, CI</ModelCollation>
        <RunSqlCodeAnalysis>true</RunSqlCodeAnalysis>
        <!-- Treat all validation results from Coding4Fun.TransactSql.Analyzers as errors. -->
        <SqlCodeAnalysisRules>$(SqlCodeAnalysisRules);+!Coding4Fun.SR1001;+!Coding4Fun.SR1002;+!Coding4Fun.SR1003;+!Coding4Fun.SR1004;+!Coding4Fun.SR1005</SqlCodeAnalysisRules>
    </PropertyGroup>
   <ItemGroup>
      <!-- Enabling our custom TSQL analyzers from NuGet repository. -->
      <PackageReference Include="Coding4Fun.TransactSql.Analyzers" Version="1.0.0"/>
   </ItemGroup>
</Project>
```

Example of a legacy project, which doesn't support analyzers from NuGet:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003" ToolsVersion="4.0">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
   <!-- Different project properties -->
</Project>
```

## Rule Configuration

As I think using [editorconfig file](https://editorconfig.org/) could be convenient for storing configuration for
analyzers, but, unfortunately, during analyzing we don't have the access to this file.
As a workaround all configurations live inside the procedure `SqlAnalysisConfiguration.sql`. An example of the
configuration:

```sql
CREATE PROCEDURE [dbo].[SqlAnalysisConfiguration]
AS
BEGIN
    DECLARE
@config NVARCHAR(MAX) = N'
LatinChar                                             = [a-zA-Z];
CyrillicChar                                          = [а-яА-ЯёЁ];
LATIN_UPPER_CASE                                      = [A-Z][A-Z0-9_]+?;
latin_lower_case                                      = [a-z][a-z0-9_]+?;
LatinPascalCase                                       = [A-Z][A-Za-z0-9]+?;
latinCamelCase                                        = [a-z][A-Za-z0-9]+?;
Coding4Fun.ObjectName.Table                           = ^\[{Schema}\]\.\[TBL_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.Column                          = ^\[{Schema}\]\.\[{Table}\]\.\[{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.DefaultConstraint               = ^\[{Schema}\]\.\[{Table}\]\.\[{Column}\]\.\[DF_{Column}\]$;
Coding4Fun.ObjectName.PrimaryKeyConstraint            = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[PK_{Table}\]$;
Coding4Fun.ObjectName.UniqueConstraint                = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[UN_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.CheckConstraint                 = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[CH_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.BTreeNonUniqueClusteredIndex    = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[BTreeNonUniqueClustered_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.BTreeUniqueClusteredIndex       = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[BTreeUniqueClustered_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.BTreeNonUniqueNonClusteredIndex = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[BTreeNonUniqueNonClustered_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.BTreeUniqueNonClusteredIndex    = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[BTreeUniqueNonClustered_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.ClusteredColumnStoreIndex       = ^\[{Schema}\]\.\[{Table}\]\.\[ClusteredColumnStore_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.NonClusteredColumnStoreIndex    = ^\[{Schema}\]\.\[{Table}\]\.\[NonClusteredColumnStore_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.Procedure                       = ^\[{Schema}\]\.\[{LatinPascalCase}\]$;
Coding4Fun.ObjectName.RoutineParameter                = ^\[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{LatinPascalCase}\]$;
Coding4Fun.ObjectName.Variable                        = ^\[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{latinCamelCase}\]$;
Coding4Fun.ObjectName.Function                        = ^\[{Schema}\]\.\[{LatinPascalCase}\]$;
Coding4Fun.StringLiteral.InvalidWordMixPattern        = ({CyrillicChar}{LatinChar})|({LatinChar}{CyrillicChar})
';
END
```

Inside this procedure we must define any string literal that holds configuration in the key-value format:
```
[Key] = [Value];
```
where `Key` can be one of predefined types, which name starts with the prefix `Coding4Fun.`, or it can be user-defined
variable, which doesn't start with `Coding4Fun.`. For example, we can define `LatinChar = [a-zA-Z];` and then use it:
```
LatinChar                                      = [a-zA-Z];
CyrillicChar                                   = [а-яА-ЯёЁ];
Coding4Fun.StringLiteral.InvalidWordMixPattern = ({CyrillicChar}{LatinChar})|({LatinChar}{CyrillicChar})
```

## Analyzer Rules

### Coding4Fun.SR1001: String Literal Validation

This rule can be helpful for countries, where using of multiple languages is common and these languages have some
letters look similar.
For example Cyrillic and Latin alphabetic have a lot of similar characters:

| **Latin**    | A | B | C | E | H | K | M | O | P | T | X | Y |
|:-------------|:--|:--|:--|:--|:--|:--|:--|:--|:--|:--|:--|:--|
| **Cyrillic** | А | В | С | Е | Н | К | М | О | Р | Т | Х | У |

As you can see it has a lot of similar symbols. If it is printed on the paper - it's OK.
But if it is being compared with valid words in the dedicated alphabetic we will not find corresponding result.

To disallow a combination of symbols from multiple alphabets we have to enable this validation and add to the configuration:
```
LatinChar                                      = [a-zA-Z];
CyrillicChar                                   = [а-яА-ЯёЁ];
Coding4Fun.StringLiteral.InvalidWordMixPattern = ({CyrillicChar}{LatinChar})|({LatinChar}{CyrillicChar})
```

Examples:

```sql
-- In our configuration we prohibit mix of latin and cyrillic characters in a single word.
-- We get: SR1001 : Coding4Fun : 'ThisIsInvalidЗначение' has invalid value
DECLARE @str NVARCHAR(100) = N'ThisIsInvalidЗначение';

-- This string literal has valid value:
SET @str = N'This Is Invalid Значение';

-- We also can suppress any word from validation. To do this we must write the following line:
-- Coding4Fun.IgnoreWordValidation: ThisIsValidЗначение
DECLARE @str NVARCHAR(100) = N'ThisIsValidЗначение';
```

### Coding4Fun.SR1002: Require Schema Name

Require write schema. Example:

```
-- Expected error message: SR1002 : Coding4Fun : Object name must consists from [schema_name] and [object_name], but was: Product 
SELECT Style
FROM Product;

-- Valid with schema:
SELECT Style
FROM dbo.Product;
```

### Coding4Fun.SR1003: Validation of Object Name Format

Unfortunately TSQL doesn't have its own official naming rules and everyone writes object names as he wants. To unify naming
we can define naming validations. For example, if every table in our project must start with `TBL_` prefix we must define
in the config:
```
LATIN_UPPER_CASE            = [A-Z][A-Z0-9_]+?;
Coding4Fun.ObjectName.Table = ^\[{Schema}\]\.\[TBL_{LATIN_UPPER_CASE}\]$;
```
where `Schema` is the system-defined variable, that will be substituted with a name of table's schema during validation. 
If this rule will be configured and our project contain the table  with name `dbo.MY_TABLE` then we get the error:
```sql
-- Expected error message: SR1003 : Coding4Fun : Object name 'MY_TABLE' doesn't match the pattern: '^\[{Schema}\]\.\[TBL_{LATIN_UPPER_CASE}\]$'
CREATE TABLE dbo.MY_TABLE (ID INT NOT NULL);
```

#### Availability of System-Defined Variables Depending on the Context

| Тип проверки                                          | {Schema} | {Table} | {Column} |
|-------------------------------------------------------|----------|---------|----------|
| Coding4Fun.ObjectName.Table                           | +        | -       | -        |
| Coding4Fun.ObjectName.Column                          | +        | +       | -        |
| Coding4Fun.ObjectName.DefaultConstraint               | +        | +       | -/+      |
| Coding4Fun.ObjectName.PrimaryKeyConstraint            | +        | +       | -/+      |
| Coding4Fun.ObjectName.UniqueConstraint                | +        | +       | -/+      |
| Coding4Fun.ObjectName.CheckConstraint                 | +        | +       | -/+      |
| Coding4Fun.ObjectName.BTreeNonUniqueClusteredIndex    | +        | +       | -/+      |
| Coding4Fun.ObjectName.BTreeUniqueClusteredIndex       | +        | +       | -/+      |
| Coding4Fun.ObjectName.BTreeNonUniqueNonClusteredIndex | +        | +       | -/+      |
| Coding4Fun.ObjectName.BTreeUniqueNonClusteredIndex    | +        | +       | -/+      |
| Coding4Fun.ObjectName.ClusteredColumnStoreIndex       | +        | +       | -        |
| Coding4Fun.ObjectName.NonClusteredColumnStoreIndex    | +        | +       | -        |
| Coding4Fun.ObjectName.Procedure                       | +        | -       | -        |
| Coding4Fun.ObjectName.RoutineParameter                | +        | -       | -        |
| Coding4Fun.ObjectName.Variable                        | +        | -       | -        |
| Coding4Fun.ObjectName.Function                        | +        | -       | -        |

### Coding4Fun.SR1004: Check for Documentation Existence

Require to describe all tables and columns

```sql
-- Expected error message: SR1004 : Coding4Fun : Table 'MY_TABLE' doesn't contain a description
CREATE TABLE [dbo].[MY_TABLE]
(
    -- Expected error message: SR1004 : Coding4Fun : Column 'ID' doesn't contain a description
    [ID] INT NOT NULL PRIMARY KEY
)
GO
```

With description:
```sql
CREATE TABLE [dbo].[TableWithDescription]
(
    [ID] INT NOT NULL PRIMARY KEY
)
GO

EXEC sys.sp_addextendedproperty
     @name       = N'MS_Description', @value      = N'Description for the table.',
     @level0type = N'SCHEMA',         @level0name = N'dbo',
     @level1type = N'TABLE',          @level1name = N'TableWithDescription';
GO

EXEC sys.sp_addextendedproperty
     @name       = N'MS_Description', @value      = N'Description for the column.',
     @level0type = N'SCHEMA',         @level0name = N'dbo',
     @level1type = N'TABLE',          @level1name = N'TableWithDescription',
     @level2type = N'COLUMN',         @level2name = N'ID';
GO
```

### Coding4Fun.SR1005: TOP (N) Requires ORDER BY Clause

According to [recommendations from Microsoft](https://learn.microsoft.com/en-us/sql/t-sql/queries/top-transact-sql?view=sql-server-ver16),
on using `TOP` we should write `ORDER BY`:
> In a SELECT statement, always use an ORDER BY clause with the TOP clause. Because, it's the only way to predictably
> indicate which rows are affected by TOP.

Without `ORDER BY`:
```sql
SELECT TOP(10) *
FROM dbo.MY_TABLE;
```

With `ORDER BY`:
```sql
SELECT TOP(10) *
FROM dbo.MY_TABLE
ORDER BY MY_TABLE_COLUMN_1,
         MY_TABLE_COLUMN_2;
```

### Coding4Fun.SR1006: TOP (N) Requires ORDER BY Clause

This rule searches for variables, that can be assigned with values, but are note used.

Example:

```sql
CREATE PROCEDURE dbo.AssignedButNotUsed
AS
    -- Expected error message: SR1006 : Coding4Fun : Variable @someUsefulValue is defined, but was newer used.
    DECLARE @someUsefulValue INT = 123;

    -- It writes to variable
    SELECT @someUsefulValue = 1
    FROM #MY_TABLE;

    SET @someUsefulValue = 321;
```

## Projects Inside this Solution

### SyntaxTreeExplainer

For writing own validations we must explain the syntax tree with smelling nodes. To do it we should insert an SQL
into this module and set up a breakpoint after a syntax tree parsing. Then we should debug this application and
insect a syntax tree using out favorite IDE.

### Analyzers

It's a main project which contains validation rules for TSQL. The artifacts for this project is archiving into the nuget-package.

### ExampleSqlProject

It is a sqlproj that includes a reference to our analyzer from NuGet Repository. We can build this project from the IDE
to see validation errors in the corresponding window after building.

### ModuleTest

This project is intended for the Test Driven Development. If we write analyzers, we have to cover it with corresponding
tests.

For example, we have a rule `NotDeterministicSelectRule` in the project `Analyzers`. To write tests for this rule we must:
1. Add line to `RuleTests.cs`:
   ```csharp
    [Theory]
    [TestDirectory(TestDataRoot + nameof(NotDeterministicSelectRule))]
    public void TestNotDeterministicSelectRule(string fileName) => Test<NotDeterministicSelectRule>(fileName);
   ```
2. Create the directory by path `ModuleTest\TestData\Rule\NotDeterministicSelectRule`
3. Add test case with **valid** TSQL (without smelling). For example:
   ```SQL
   CREATE PROCEDURE dbo.TopWithOrderByDoesNotThrow
   AS
   SELECT TOP (1) A
   FROM #T
   ORDER BY A;
   ```
4. Add test case with **invalid** TSQL (with smelling). For example:
   ```SQL
   CREATE PROCEDURE dbo.TopWithoutOrderByThrows
   AS
   -- Expected error message: SR1005 : Coding4Fun : TOP (N) requires ORDER BY clause
   SELECT TOP (1) 1
   FROM #T;
   ```
   As you can mention, the test infrastructure provide an ability to check, that analyzer must throw an error. To use this
   feature we must write a prefix inside comment: `Expected error message: ` and after it write the message of error.

## Notes

For working with some validation rules we have to add this configuration into the sqlproj:
```xml
<IgnoreComments>False</IgnoreComments>
```


## Step-by-step guide: creating own TSQL-analyzers

1. Create an empty TSQL-project in SDK-style using [Official Microsoft Documentation](https://github.com/microsoft/DacFx?tab=readme-ov-file#-create-a-sql-project)
2. Create the basic [code analysis rule WaitForDelay](https://github.com/microsoft/DacFx/blob/main/src/Microsoft.Build.Sql.Templates/README.md#new-sample-code-analysis-rule)
3. Include your WaitForDelay rule into your TSQL project:
   ```
   <ItemGroup>
     <PackageReference Include="Coding4Fun.TransactSql.Analyzers" Version="1.0.0" />
   </ItemGroup>
   ```
4. Build your TSQL-project and you will see errors from your analyzer.

## Useful links

* [Microsoft | Extending the Database Features](https://learn.microsoft.com/en-us/sql/ssdt/extending-the-database-features?view=sql-server-ver16)
* [Microsoft | Analyzing Database Code to Improve Code Quality
  Article
  02/04/2013](https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2010/dd172133(v=vs.100))
* [Microsoft | Devblogs | Programmatically parsing Transact SQL (T-SQL) with the ScriptDom parser](https://devblogs.microsoft.com/azure-sql/programmatically-parsing-transact-sql-t-sql-with-the-scriptdom-parser/)
* [GitHub | DacFx](https://github.com/microsoft/DacFx)
* [Path to extension is not possible to customize](https://learn.microsoft.com/en-us/sql/ssdt/how-to-install-and-manage-feature-extensions?view=sql-server-ver16)

## Examples with validation rules

* [microsoft | DACExtensions](https://github.com/microsoft/DACExtensions)
* [Tobichimaru | EPAM_NET](https://github.com/Tobichimaru/EPAM_NET/tree/master/EPAM_Mentoring-D1-D2/11.%20Tools%20for%20developer/01.%20Static%20Code%20Analize/SSDT)
* [davebally | TSQL-Smells](https://github.com/davebally/TSQL-Smells/tree/master)
* [Serviceware | Dibix](https://github.com/Serviceware/Dibix/tree/main)
* [cheburashka | dedmedved](https://github.com/dedmedved/cheburashka)
* [tcartwright | SqlServer.Rules](https://github.com/tcartwright/SqlServer.Rules)
* [rr-wfm | MSBuild.Sdk.SqlProj](https://github.com/rr-wfm/MSBuild.Sdk.SqlProj/tree/master)