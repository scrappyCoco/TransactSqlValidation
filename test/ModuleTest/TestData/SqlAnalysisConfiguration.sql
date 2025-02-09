CREATE PROCEDURE [dbo].[SqlAnalysisConfiguration]
AS
BEGIN
    DECLARE @config NVARCHAR(MAX) = N'
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
    SELECT @config;
END