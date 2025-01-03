CREATE PROCEDURE [dbo].[SqlAnalysisConfiguration]
AS
BEGIN
    DECLARE @config NVARCHAR(MAX) = N'
Coding4Fun.ObjectName.LATIN_UPPER_CASE                = [A-Z][A-Z0-9_]+?;
Coding4Fun.ObjectName.latin_lower_case                = [a-z][a-z0-9_]+?;
Coding4Fun.ObjectName.LatinPascalCase                 = [A-Z][A-Za-z0-9]+?;
Coding4Fun.ObjectName.latinCamelCase                  = [a-z][A-Za-z0-9]+?;
Coding4Fun.ObjectName.Table                           = ^\[{Schema}\]\.\[P_{LATIN_UPPER_CASE}_S\]$;
Coding4Fun.ObjectName.Column                          = ^\[{Schema}\]\.\[{Table}\]\.\[{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.DefaultConstraint               = ^\[{Schema}\]\.\[{Table}\]\.\[{Column}\]\.\[DF_{Column}\]$;
Coding4Fun.ObjectName.PrimaryKeyConstraint            = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[PK_{Table}\]$;
Coding4Fun.ObjectName.UniqueConstraint                = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[UN_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.CheckConstraint                 = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[CH_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.BTreeNonUniqueClusteredIndex    = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IXNUC_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.BTreeUniqueClusteredIndex       = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IXUC_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.BTreeNonUniqueNonClusteredIndex = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IXNUNC_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.BTreeUniqueNonClusteredIndex    = ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[IXUNC_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.ClusteredColumnStoreIndex       = ^\[{Schema}\]\.\[{Table}\]\.\[CSC_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.NonClusteredColumnStoreIndex    = ^\[{Schema}\]\.\[{Table}\]\.\[CSNC_{Table}_{LATIN_UPPER_CASE}\]$;
Coding4Fun.ObjectName.Procedure                       = ^\[{Schema}\]\.\[{LatinPascalCase}\]$;
Coding4Fun.ObjectName.RoutineParameter                = ^\[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{LatinPascalCase}\]$;
Coding4Fun.ObjectName.Variable                        = ^\[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{latinCamelCase}\]$;
Coding4Fun.ObjectName.Function                        = ^\[{Schema}\]\.\[{LatinPascalCase}\]$;
Coding4Fun.StringLiteral.InvalidWordMixPattern                      = ([a-zA-Z][а-яА-ЯёЁ])|([а-яА-ЯёЁ][a-zA-Z]);';
;
END