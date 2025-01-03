-- DEFINE {LATIN_UPPER_CASE} => [A-Z][A-Z0-9_]+?
-- DEFINE {latin_lower_case} => [a-z][a-z0-9_]+?
-- DEFINE {LatinPascalCase}  => [A-Z][A-Za-z0-9]+?
-- DEFINE {latinCamelCase}   => [a-z][A-Za-z0-9]+?

-- Coding4fun.ObjectName.Table
-- Pattern: \[{Schema}\]\.\[TBL_{LATIN_UPPER_CASE}\]
-- Render:  \[dbo\]\.\[TBL_[A-Z][A-Z0-9_]+?\]
CREATE TABLE [dbo].[TBL_PERSON]
(
    -- Coding4fun.ObjectName.Column
    -- Pattern: \[{Schema}\]\.\[{Table}\]\.\[{Table}_{LATIN_UPPER_CASE}\]
    -- Render:  \[dbo\]\.\[TBL_PERSON\]\.\[TBL_PERSON_[A-Z][A-Z0-9_]+?\]
    [TBL_PERSON_ID] INT

    -- Coding4fun.ObjectName.PrimaryKeyConstraint
    -- Pattern: \[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[PK_{Table}\]
    -- Render:  \[dbo\]\.\[TBL_PERSON\]\.(\[TBL_PERSON_ID\]\.)?\[PK_TBL_PERSON\]
        CONSTRAINT [PK_TBL_PERSON] PRIMARY KEY,
    
    -- Same, but not after column definition
    CONSTRAINT [PK_TBL_PERSON] PRIMARY KEY (TBL_PERSON_ID),

    -- Coding4fun.ObjectName.Column
    -- Pattern: \[{Schema}\]\.\[{Table}\]\.\[{Table}_{LATIN_UPPER_CASE}\]
    -- Render:  \[dbo\]\.\[TBL_PERSON\]\.\[TBL_PERSON_[A-Z][A-Z0-9_]+?\]
    -- Expected error message: SR1003 : Coding4Fun : Object name 'ID' doesn't match the pattern: '^\[{Schema}\]\.\[{Table}\]\.\[{Table}_{LATIN_UPPER_CASE}\]$'
    ID INT,

    -- Coding4fun.ObjectName.UniqueConstraint
    -- Pattern: \[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[UN_{Table}_{LATIN_UPPER_CASE}\]
    -- Render:  \[dbo\]\.\[TBL_PERSON\]\.(\[TBL_PERSON_DOCUMENT_NUMBER\]\.)?\[UN_TBL_PERSON_[A-Z][A-Z0-9_]+?\]
    TBL_PERSON_DOCUMENT_NUMBER VARCHAR(50) NOT NULL
        CONSTRAINT UN_TBL_PERSON_DOCUMENT_NUMBER_1 UNIQUE,
    -- Same, but not after column definition
    CONSTRAINT UN_TBL_PERSON_DOCUMENT_NUMBER_2 UNIQUE (TBL_PERSON_DOCUMENT_NUMBER),

    -- Coding4fun.ObjectName.DefaultConstraint
    -- Pattern: \[{Schema}\]\.\[{Table}\]\.\[{Column}\]\.\[DF_{Column}\]
    -- Render:  \[dbo\]\.\[TBL_PERSON\]\.\[DF_TBL_PERSON_IS_RESIDENT\]\.\[DF_TBL_PERSON_IS_RESIDENT\]
    TBL_PERSON_IS_RESIDENT BIT
        CONSTRAINT DF_TBL_PERSON_IS_RESIDENT DEFAULT 1,

    -- Coding4fun.ObjectName.BTreeNonUniqueClusteredIndex
    -- Pattern: \[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[BTreeNonUniqueClustered_{Table}_{LATIN_UPPER_CASE}\]
    -- Render:  \[dbo\]\.\[TBL_PERSON\]\.\[BTreeNonUniqueClustered_TBL_PERSON_[A-Z][A-Z0-9_]+?\]
    TBL_PERSON_LAST_NAME VARCHAR(50) NOT NULL INDEX BTreeNonUniqueClustered_TBL_PERSON_LAST_NAME CLUSTERED,
    INDEX BTreeNonUniqueClustered_TBL_PERSON_LAST_NAME CLUSTERED (TBL_PERSON_LAST_NAME),

    -- Coding4fun.ObjectName.BTreeUniqueClusteredIndex
    -- Pattern: \[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[BTreeUniqueClustered_{Table}_{LATIN_UPPER_CASE}\]
    -- Render:  \[dbo\]\.\[TBL_PERSON\]\.\[BTreeUniqueClustered_TBL_PERSON_[A-Z][A-Z0-9_]+?\]
    TBL_PERSON_GUID UNIQUEIDENTIFIER,
    INDEX BTreeUniqueClustered_TBL_PERSON_GUID UNIQUE CLUSTERED (TBL_PERSON_GUID),

    -- Coding4fun.ObjectName.BTreeNonUniqueNonClusteredIndex
    -- Pattern: \[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[BTreeNonUniqueNonClustered_{Table}_{LATIN_UPPER_CASE}\]
    -- Render:  \[dbo\]\.\[TBL_PERSON\]\.\[BTreeNonUniqueNonClustered_TBL_PERSON_[A-Z][A-Z0-9_]+?\]
    TBL_PERSON_FIRST_NAME INT INDEX BTreeNonUniqueNonClustered_TBL_PERSON_FIRST_NAME NONCLUSTERED,
    INDEX BTreeNonUniqueNonClustered_TBL_PERSON_FIRST_NAME NONCLUSTERED (TBL_PERSON_FIRST_NAME),

    -- Expected error message: SR1003 : Coding4Fun : Object name 'IX_FIRST_NAME' doesn't match the pattern: '^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[BTreeNonUniqueNonClustered_{Table}_{LATIN_UPPER_CASE}\]$'
    INDEX IX_FIRST_NAME NONCLUSTERED (TBL_PERSON_FIRST_NAME)
);
GO