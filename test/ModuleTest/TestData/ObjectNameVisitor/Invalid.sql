-- DEFINE {LATIN_UPPER_CASE} => [A-Z][A-Z0-9_]+?
-- DEFINE {latin_lower_case} => [a-z][a-z0-9_]+?
-- DEFINE {LatinPascalCase}  => [A-Z][A-Za-z0-9]+?
-- DEFINE {latinCamelCase}   => [a-z][A-Za-z0-9]+?

-- Pattern: ^\[{Schema}\]\.\[P_{LATIN_UPPER_CASE}_S\]$
-- Render:  ^\[{dbo}\]\.\[P_[A-Z][A-Z0-9_]+?_S]$
CREATE TABLE dbo.MY_TABLE
(
    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.\[{Table}_{LATIN_UPPER_CASE}\]$
    -- Render:  ^\[dbo\]\.\[MY_TABLE\]\.\[MY_TABLE_[A-Z][A-Z0-9_]+?\]$
    _MY_TABLE_COLUMN INT,

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[PK_{Table}\]$
    -- Render:  ^\[dbo\]\.\[MY_TABLE\]\.(\[MY_TABLE_ID_1\]\.)?\[PK_MY_TABLE\]$
    MY_TABLE_ID_1    INT
        CONSTRAINT PK_MY_TABLE PRIMARY KEY,
    CONSTRAINT MY_TABLE_PK PRIMARY KEY (MY_TABLE_ID_1),

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[UN_{Table}_{LATIN_UPPER_CASE}\]$
    -- Render:  ^\[dbo\]\.\[MY_TABLE\]\.(\[MY_TABLE_ID_2\]\.)?\[UN_MY_TABLE_[A-Z][A-Z0-9_]+?\]$
    MY_TABLE_ID_2    INT
        CONSTRAINT UN_MY_TABLE_SUFFIX UNIQUE,
    CONSTRAINT MY_TABLE_SUFFIX_UN UNIQUE (MY_TABLE_ID_2),

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.\[{Column}\]\.\[DF_{Column}\]$
    -- Render:  ^\[dbo\]\.\[MY_TABLE_ID_3\]\.\[MY_TABLE_ID_3\]\.\[DF_MY_TABLE_MY_TABLE_ID_3\]$
    MY_TABLE_ID_3    INT
        CONSTRAINT MY_TABLE_ID_3_DF DEFAULT 0,

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.\[IXNUC_{Table}_{LATIN_UPPER_CASE}\]$
    -- Render:  ^\[dbo\]\.\[MY_TABLE\]\.\[IXNUC_MY_TABLE_[A-Z][A-Z0-9_]+?\]$
    MY_TABLE_ID_4    INT INDEX MY_TABLE_SUFFIX_IXNUC CLUSTERED,
    -- INDEX MY_TABLE_SUFFIX_IXNUC CLUSTERED (MY_TABLE_ID_4),

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.\[IXUC_{Table}_{LATIN_UPPER_CASE}\]$
    -- Render:  ^\[dbo\]\.\[MY_TABLE\]\.\[IXUC_MY_TABLE_[A-Z][A-Z0-9_]+?\]$
    MY_TABLE_ID_5    INT,

    -- MY_TABLE_ID_5 INT UNIQUE INDEX IXUC_MY_TABLE_SUFFIX CLUSTERED,
    -- Msg 10793, Level 16, State 0, Line 1
    -- Both an index and a PRIMARY KEY constraint have been defined inline, with the definition of column 'MY_TABLE_ID', table 'dbo.MY_TABLE'.
    -- Defining both an index and a PRIMARY KEY constraint inline with the column definition is not allowed.
    INDEX MY_TABLE_SUFFIX_IXUC UNIQUE CLUSTERED (MY_TABLE_ID_5),

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.\[IXNUNC_{Table}_{LATIN_UPPER_CASE}\]$
    -- Render:  ^\[dbo\]\.\[MY_TABLE\]\.\[IXNUNC_MY_TABLE_[A-Z][A-Z0-9_]+?\]$
    MY_TABLE_ID_6    INT INDEX IXNUNC_MY_TABLE_SUFFIX NONCLUSTERED,
    INDEX MY_TABLE_SUFFIX_IXNUNC NONCLUSTERED (MY_TABLE_ID_6),

    MY_TABLE_ID_7    INT,
    -- It doesn't work:
    -- MY_TABLE_ID_7 INT UNIQUE INDEX IXUNC_MY_TABLE_SUFFIX NONCLUSTERED,
    INDEX MY_TABLE_SUFFIX_IXUNC UNIQUE NONCLUSTERED (MY_TABLE_ID_7),

    MY_TABLE_ID_8    INT,
    INDEX MY_TABLE_SUFFIX_CSC CLUSTERED COLUMNSTORE,

    MY_TABLE_ID_9    INT,
    INDEX MY_TABLE_SUFFIX_CSNC NONCLUSTERED COLUMNSTORE (MY_TABLE_ID_9)
);
GO

CREATE PROCEDURE dbo.MyProc
AS
SELECT 'Hello World';
GO

CREATE FUNCTION dbo.MyScalarFunc() RETURNS VARCHAR(MAX)
AS
BEGIN
    RETURN 'Hello World';
END