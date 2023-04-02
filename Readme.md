# BI.VS.Validations

Данный проект может оказаться полезным компаниям, которые используют [SQL Server Data Tools](https://visualstudio.microsoft.com/vs/features/ssdt/).
По мере разрастания проекта, появляются некоторые требования к стилю написания кода.
Чтобы не тратить много времени на проверку этих требований при проведении code review, хочется иметь инструмент, проводящий автоматическую проверку этих правил.
В проекте sqlproj имеется механизм проверки кода. Из "коробки" поставляются некоторые [правила](https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2010/dd172133(v=vs.100)).
Но нам их не достаточно - мы написали свои, согласно нашим требованиям. Рекомендуется ознакомиться с написанием собственных правил в [первоисточнике](https://learn.microsoft.com/en-us/sql/ssdt/overview-of-extensibility-for-database-code-analysis-rules?view=sql-server-ver16).

## Проверки

### Coding4fun.SR1001: String literal validation

Проверка значения на соответствие регулярному выражению во всех строковых литералах, используемых в функциях, процедурах и триггерах. Если строка соответствует регулярному выражению, то случится ошибка.
Чтобы предотвратить сочетание кириллицы и латиницы необходимо заполнить конфигурацию в файл проекта:
```
<ContributorArguments>
  $(ContributorArguments);
  Coding4fun.StringLiteral.InvalidPattern = (?i:[а-яё][a-z])|([a-z][а-яё]));
</ContributorArguments>
```

Чаще всего в коде встречается латинская буква `c` вместо кириллицы `с`. Связано это с тем, что они расположены на одной клавише клавиатуры. 

Примеры:

```sql
-- Так нельзя:
DECLARE @str NVARCHAR(100) = N'ThisIsInvalidЗначение';

-- А так можно:
SET @str = N'This Is Invalid Значение';
```

### Coding4fun.SR1002: Require schema name

При обращении к объектам рекомендуется писать `[наименование_схемы].[наименование_объекта]`. Не допускается `[наименование_объекта]` (без указания схемы), либо `[наименование_бд].[наименование_схемы].[наименование_объекта]` (с лишним названием БД).

### Coding4fun.SR1003: Validation of object name format

Официальных рекомендаций по наименованию объектов TSQL нет. У каждой компании, команды, проекта могут быть свои правила наименования объектов. Для их объявления необходимо в sqlproj добавить следующую конфигурацию:

```xml
  <PropertyGroup>
    <BuildContributors>
      $(BuildContributors);SampleRules.BuildContributors.ConfigLoaderBuildContributor
    </BuildContributors>
    <ContributorArguments>
$(ContributorArguments);
Coding4fun.ObjectName.LATIN_UPPER_CASE                    = [A-Z][A-Z0-9]*(_[A-Z0-9])*?;
Coding4fun.ObjectName.latin_lower_case                    = [a-z][a-z0-9]*(_[a-z0-9])*?;
Coding4fun.ObjectName.LatinPascalCase                     = [A-Z][A-Za-z0-9]*?;
Coding4fun.ObjectName.latinCamelCase                      = [a-z][a-z0-9]*([A-Z]+[a-z0-9]+)*?;
Coding4fun.ObjectName.Table                               = ^(\[{Schema}\]\.\[MY_{LATIN_UPPER_CASE}\]|\[import\].+)$;
Coding4fun.ObjectName.Column                              = ^(\[{Schema}\]\.\[{Table}\]\.\[{Table}_{LATIN_UPPER_CASE}\]|\[import\].+)$;
Coding4fun.ObjectName.DefaultConstraint                   = ^\[{Schema}\]\.\[{Table}\]\.\[{Column}\]\.\[DF_{Column}\]$;
Coding4fun.ObjectName.PrimaryKeyConstraint                = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[PK_{Table}\]$;
Coding4fun.ObjectName.UniqueConstraint                    = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[UN_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.CheckConstraint                     = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[CH_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.BTreeNonUniqueClusteredIndex        = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.BTreeUniqueClusteredIndex           = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.BTreeNonUniqueNonClusteredIndex     = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.BTreeUniqueNonClusteredIndex        = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.ClusteredColumnStoreIndex           = ^\[{Schema}\]\.\[{Table}\]\.\[CS_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.NonClusteredColumnStoreIndex        = ^\[{Schema}\]\.\[{Table}\]\.\[CS_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4fun.ObjectName.Procedure                           = ^\[{Schema}\]\.\[{LatinPascalCase}\]$;
Coding4fun.ObjectName.RoutineParameter                    = ^\[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{LatinPascalCase}\]$;
Coding4fun.ObjectName.Variable                            = ^\[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{latinCamelCase}\]$;
Coding4fun.ObjectName.Function                            = ^\[{Schema}\]\.\[{LatinPascalCase}\]$;
    </ContributorArguments>
    <StaticCodeAnalysisDependsOn>
      $(StaticCodeAnalysisDependsOn);Build;
    </StaticCodeAnalysisDependsOn>
  </PropertyGroup>
```

В блоке `BuildContributors` происходит объявление инициализатора конфигурации `ConfigLoaderBuildContributor`, который считывает `ContributorArguments`.
`ConfigLoaderBuildContributor` запускается после построения проекта. Блок `ContributorArguments` состоит из списка пар `<название_параметра> = <значение>;`.
`<название_параметра>` должно начинаться с префикса `Coding4fun.ObjectName.` + `<название_переменной> | <тип_объекта>`.
Переменные создаются для дальнейшего использования в значении `<тип_объекта>`. В значении указывается регулярное выражение.
Внутри регулярного выражения доступны переменные контекста (название таблицы, схемы, столбца). Давайте разберем пример правила наименования таблицы.

#### Пример таблицы
```sql
CREATE TABLE dbo.MY_TABLE
(
    MY_TABLE_ID INT PRIMARY KEY
);
```

При валидации наименования таблицы будет сформирован логический путь к проверяемому объекту: `[dbo].[MY_TABLE]`

При валидации правилом `Coding4fun.ObjectName.Table = ^\[{Schema}\]\.\[MY_{LATIN_UPPER_CASE}\]$;` произойдет подстановка переменных контекста и регулярное выражение примет следующий вид: `^\[dbo\]\.\[MY_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$`,
что в свою очередь означает: любая таблица должна начинаться с префикса `MY_` (в верхнем регистре) и за ним следует название в `UPPER_CASE`.
Если регулярное выражение не совпадет с названием таблицы, то будет сгенерирована ошибка (либо предупреждение).

Если имеется потребность отключить валидации для какой-либо схемы (предположим `import`), то необходимо дописать правило:
```
Coding4fun.ObjectName.Table = ^(\[{Schema}\]\.\[MY_{LATIN_UPPER_CASE}\]|\[import\].+)$;
```

#### Пример индекса
```sql
-- Пример 1:
CREATE TABLE dbo.MY_TABLE_1
(
    MY_TABLE_1_ID INT INDEX IX_MY_TABLE_1_ID
);

-- Пример 2:
CREATE TABLE dbo.MY_TABLE_2
(
    MY_TABLE_2_ID INT,
    INDEX IX_MY_TABLE_2_ID (MY_TABLE_2_ID)
);
```

Для первого примера будет сформирован следующий путь для названия индекса: `[dbo].[MY_TABLE_1].[MY_TABLE_1_ID].[IX_MY_TABLE_1_ID]`.
Для второго примера название столбца в пути будет отсутствовать: `[dbo].[MY_TABLE_1].[IX_MY_TABLE_1_ID]`.
Это стоит учитывать при написании правил:
```
Coding4fun.ObjectName.BTreeNonUniqueNonClusteredIndex = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IX_{Table}_{LATIN_UPPER_CASE}\]$;
```
Можете заметить, что в регулярном выражении название столбца сделано опциональным. Также обратите внимание, что название индекса должно начинаться с префикса `IX_`, далее следует название таблицы и произвольный суффикс в `UPPER_CASE`.
В сформированном виде регулярное выражение примет следующий вид: `^\[dbo\]\.\[MY_TABLE_1\]\.(\[MY_TABLE_1_ID\]\.)?\[IX_MY_TABLE_1_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$`
А для второго случая: `^\[dbo\]\.\[MY_TABLE_2\]\.(\[{Column}\]\.)?\[IX_MY_TABLE_2_[A-Z][A-Z0-9]*(_[A-Z0-9])*?\]$` (т.е. `{Column}` ничем не заменится).

#### Описание переменных контекста в зависимости от типа проверки

| Тип проверки                                          | {Schema} | {Table} | {Column} |
|-------------------------------------------------------|----------|---------|----------|
| Coding4fun.ObjectName.Table                           | +        | -       | -        |
| Coding4fun.ObjectName.Column                          | +        | +       | -        |
| Coding4fun.ObjectName.DefaultConstraint               | +        | +       | -/+      |
| Coding4fun.ObjectName.PrimaryKeyConstraint            | +        | +       | -/+      |
| Coding4fun.ObjectName.UniqueConstraint                | +        | +       | -/+      |
| Coding4fun.ObjectName.CheckConstraint                 | +        | +       | -/+      |
| Coding4fun.ObjectName.BTreeNonUniqueClusteredIndex    | +        | +       | -/+      |
| Coding4fun.ObjectName.BTreeUniqueClusteredIndex       | +        | +       | -/+      |
| Coding4fun.ObjectName.BTreeNonUniqueNonClusteredIndex | +        | +       | -/+      |
| Coding4fun.ObjectName.BTreeUniqueNonClusteredIndex    | +        | +       | -/+      |
| Coding4fun.ObjectName.ClusteredColumnStoreIndex       | +        | +       | -        |
| Coding4fun.ObjectName.NonClusteredColumnStoreIndex    | +        | +       | -        |
| Coding4fun.ObjectName.Procedure                       | +        | -       | -        |
| Coding4fun.ObjectName.RoutineParameter                | +        | -       | -        |
| Coding4fun.ObjectName.Variable                        | +        | -       | -        |
| Coding4fun.ObjectName.Function                        | +        | -       | -        |

### Coding4fun.SR1004: Check for documentation existence

Хорошо, когда есть документация на таблицу и плохо когда её нет. Так давайте сделаем хорошо!

Пример таблицы, у которой имеется описание:
```sql
CREATE TABLE [dbo].[MY_TABLE](
    [MY_TABLE_ID]    INT NOT NULL,
    [MY_TABLE_VALUE] INT NOT NULL,
    CONSTRAINT [PK_MY_TABLE] PRIMARY KEY CLUSTERED ([MY_TABLE_ID])
);
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description', @value      = N'Ключ очень важной сущности',
    @level0type = N'SCHEMA',   @level0name = N'dbo',
    @level1type = N'TABLE',    @level1name = N'MY_TABLE',
    @level2type = N'COLUMN',   @level2name = N'MY_TABLE_ID'
GO
EXEC sp_addextendedproperty
    @name = N'MS_Description', @value      = N'Очень важное значение',
    @level0type = N'SCHEMA',   @level0name = N'dbo',
    @level1type = N'TABLE',    @level1name = N'MY_TABLE',
    @level2type = N'COLUMN',   @level2name = N'MY_TABLE_VALUE'
GO
EXEC sp_addextendedproperty
     @name = N'MS_Description', @value      = N'Очень важная таблица',
     @level0type=N'SCHEMA',     @level0name = N'dbo',
     @level1type=N'TABLE',      @level1name = N'MY_TABLE'
GO
```

Если будут отсутствовать документация на какой-либо столбец, либо на саму таблицу, то будет выведена ошибка.
### Coding4fun.SR1005: TOP (N) requires ORDER BY clause

Согласно [рекомендациям от Microsoft](https://learn.microsoft.com/en-us/sql/t-sql/queries/top-transact-sql?view=sql-server-ver16), при использовании `TOP` необходимо писать `ORDER BY`:
> In a SELECT statement, always use an ORDER BY clause with the TOP clause. Because, it's the only way to predictably indicate which rows are affected by TOP.

Плохой пример:
```sql
SELECT TOP (10) *
FROM dbo.MY_TABLE;
```

Как надо:
```sql
SELECT TOP (10) *
FROM dbo.MY_TABLE
ORDER BY MY_TABLE_COLUMN_1,
         MY_TABLE_COLUMN_2;
```

## Список проектов

### SyntaxTreeExplainer

Так как нет специального плагина, либо утилиты, позволяющей просмотреть синтаксическое дерево TSQL,
приходится использовать [TSql150Parser](https://learn.microsoft.com/en-us/dotnet/api/microsoft.sqlserver.transactsql.scriptdom.tsql150parser?view=sql-dacfx-161)
и ставить точку останова (breakpoint) в IDE, чтобы исследовать синтаксическое дерево интересующего SQL запроса.
Для этого необходимо задать значение константы `sql`, поставить точку останова на закрывающей фигурной скобке, запустить отладку (debug).
В случае валидного sql переменная `tree` будет являться
корнем синтаксического дерева объявленного ранее `sql`. В противном случае в списке `errors` будут описания синтаксических ошибок.
Типы элементов, синтаксис которых должен подвергаться анализу, будет переопределен в унаследованном от [TSqlFragmentVisitor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.sqlserver.transactsql.scriptdom.tsqlfragmentvisitor?view=sql-dacfx-161) классе.

### Validation

Основной проект, ради которого всё затевалось. В нём реализованы правила проверки TSQL, указанные в начала этого описания.
Dll файл, полученный в результате компиляции должен быть скопирован в строго определенную папку:
```
C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\150
```
Но в зависимости от версии Visual Studio и SSDT этот путь может отличаться на вашем ПК.
Также стоит учесть, если вы разрабатываете в Visual Studio, то вам не удастся скопировать скомпилированную библиотеку с проверками кода
в вышеуказанный путь, так как при запуске VS происходит загрузка библиотек, лежащих в данной папке. Для отладки, желательно
использовать IDE, отличную от Visual Studio. Для этого был создан отдельный профиль отладки, который кладет скомпилированный dll
в вышеуказанную папку и происходит запуск Visual Studio в экспериментальном режиме. Для этого необходимо сделать следующее:

В файл `Validation.csproj.user` необходимо добавить:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup Condition="'$(Configuration)|$(Platform)' == 'Debug Visual Studio|AnyCPU'">
    <StartProgram>C:\Program Files %28x86%29\Microsoft Visual Studio\2019\Professional\Common7\IDE\devenv.exe</StartProgram>
    <StartArguments>/rootsuffix Exp</StartArguments>
    <StartAction>Program</StartAction>
  </PropertyGroup>
</Project>
```

В Validation.csproj:
```xml
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug Visual Studio|AnyCPU' ">
    <OutputPath>C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\150</OutputPath>
  </PropertyGroup>
```

Для компиляции данного проекта необходимо один раз [создать ключ MyRefKey.snk](https://learn.microsoft.com/en-us/sql/ssdt/walkthrough-author-custom-static-code-analysis-rule-assembly?view=sql-server-ver16#building-the-class-library).


### Benchmark

`SingleRuleValidation` производит замер производительности каждого правила по отдельности.
`VendorValidation` производит замер производительности всех встроенных правил Microsoft и отдельно все правила Coding4fun.
На вход необходимо подавать файл dacpac вашего проекта.

### ExampleSqlProject

SQL-проект, в котором есть попахивающий код. При анализе этого проекта будут отображены ошибки, найденные проектом `Validation`.
Также этот проект используется в `Benchmark`.

### ModuleTest

Используется классов, унаследованных от [TSqlFragmentVisitor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.sqlserver.transactsql.scriptdom.tsqlfragmentvisitor?view=sql-dacfx-161)
Модульный тест более легковесный, но в нём не доступна семантическая модель.
По возможности, большую часть тестов лучше разрабатывать именно в этом проекте.

## Примечания

Для работы некоторых проверок в sql-проекте необходимо добавить параметр:
```xml
<IgnoreComments>False</IgnoreComments>
```

## Полезные ссылки
* [Официальная документация Microsoft](https://learn.microsoft.com/en-us/sql/ssdt/extending-the-database-features?view=sql-server-ver16)
* [Описание валидаторов Microsoft](https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2010/dd172133(v=vs.100))
* [Microsoft | Devblogs | Programmatically parsing Transact SQL (T-SQL) with the ScriptDom parser](https://devblogs.microsoft.com/azure-sql/programmatically-parsing-transact-sql-t-sql-with-the-scriptdom-parser/)
* [GitHub | DacFx](https://github.com/microsoft/DacFx)
* [Path to extension is not possible to customize](https://learn.microsoft.com/en-us/sql/ssdt/how-to-install-and-manage-feature-extensions?view=sql-server-ver16)

## Примеры
* [microsoft | DACExtensions](https://github.com/microsoft/DACExtensions)
* [Tobichimaru | EPAM_NET](https://github.com/Tobichimaru/EPAM_NET/tree/master/EPAM_Mentoring-D1-D2/11.%20Tools%20for%20developer/01.%20Static%20Code%20Analize/SSDT)
* [davebally | TSQL-Smells](https://github.com/davebally/TSQL-Smells/tree/master)
* [Serviceware | Dibix](https://github.com/Serviceware/Dibix/tree/main)
* [cheburashka | dedmedved](https://github.com/dedmedved/cheburashka)
* [tcartwright | SqlServer.Rules](https://github.com/tcartwright/SqlServer.Rules)

## Пути
* C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Microsoft\VisualStudio\v16.0\SSDT\Microsoft.Data.Tools.Schema.SqlTasks.targets
* C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\150

<!-- TODO: Добавить проверку формата параметров и переменных, табличных переменных, временных таблиц -->