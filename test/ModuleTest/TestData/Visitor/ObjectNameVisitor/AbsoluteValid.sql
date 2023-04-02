-- DEFINE {LATIN_UPPER_CASE} => [A-Z][A-Z0-9_]+?
-- DEFINE {latin_lower_case} => [a-z][a-z0-9_]+?
-- DEFINE {LatinPascalCase}  => [A-Z][A-Za-z0-9]+?
-- DEFINE {latinCamelCase}   => [a-z][A-Za-z0-9]+?

-- Pattern: ^\[{Schema}\]\.\[P_{LATIN_UPPER_CASE}_S]$
-- Render:  ^\[{dbo}\]\.\[P_[A-Z][A-Z0-9_]+?_S]$
CREATE TABLE dbo.P_MY_SUPER_TABLE_S
(
    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.\[{Table}_{LATIN_UPPER_CASE}\]$
    -- Render:  ^\[dbo\]\.\[P_MY_SUPER_TABLE_S\]\.\[P_MY_SUPER_TABLE_S_[A-Z][A-Z0-9_]+?\]$
    P_MY_SUPER_TABLE_S_COLUMN INT,

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[PK_{Table}\]$
    -- Render:  ^\[dbo\]\.\[P_MY_SUPER_TABLE_S\]\.(\[P_MY_SUPER_TABLE_S_ID_1\]\.)?\[PK_P_MY_SUPER_TABLE_S\]$
    P_MY_SUPER_TABLE_S_ID_1   INT
        CONSTRAINT PK_P_MY_SUPER_TABLE_S PRIMARY KEY,
    CONSTRAINT PK_P_MY_SUPER_TABLE_S PRIMARY KEY (P_MY_SUPER_TABLE_S_ID_1),

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.(\[{Column}\]\.)?\[UN_{Table}_{LATIN_UPPER_CASE}\]$
    -- Render:  ^\[dbo\]\.\[P_MY_SUPER_TABLE_S\]\.(\[P_MY_SUPER_TABLE_S_ID_2\]\.)?\[UN_P_MY_SUPER_TABLE_S_[A-Z][A-Z0-9_]+?\]$
    P_MY_SUPER_TABLE_S_ID_2   INT
        CONSTRAINT UN_P_MY_SUPER_TABLE_S_SUFFIX UNIQUE,
    CONSTRAINT UN_P_MY_SUPER_TABLE_S_SUFFIX UNIQUE (P_MY_SUPER_TABLE_S_ID_2),

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.\[{Column}\]\.\[DF_{Column}\]$
    -- Render:  ^\[dbo\]\.\[P_MY_SUPER_TABLE_S_ID_3\]\.\[P_MY_SUPER_TABLE_S_ID_3\]\.\[DF_P_MY_SUPER_TABLE_S_P_MY_SUPER_TABLE_S_ID_3\]$
    P_MY_SUPER_TABLE_S_ID_3   INT
        CONSTRAINT DF_P_MY_SUPER_TABLE_S_ID_3 DEFAULT 0,

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.\[IXNUC_{Table}_{LATIN_UPPER_CASE}\]$
    -- Render:  ^\[dbo\]\.\[P_MY_SUPER_TABLE_S\]\.\[IXNUC_P_MY_SUPER_TABLE_S_[A-Z][A-Z0-9_]+?\]$
    P_MY_SUPER_TABLE_S_ID_4   INT INDEX IXNUC_P_MY_SUPER_TABLE_S_SUFFIX CLUSTERED,
    INDEX IXNUC_P_MY_SUPER_TABLE_S_SUFFIX CLUSTERED (P_MY_SUPER_TABLE_S_ID_4),

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.\[IXUC_{Table}_{LATIN_UPPER_CASE}\]$
    -- Render:  ^\[dbo\]\.\[P_MY_SUPER_TABLE_S\]\.\[IXUC_P_MY_SUPER_TABLE_S_[A-Z][A-Z0-9_]+?\]$
    P_MY_SUPER_TABLE_S_ID_5   INT,
    -- P_MY_SUPER_TABLE_S_ID_5 INT UNIQUE INDEX IXUC_P_MY_SUPER_TABLE_S_SUFFIX CLUSTERED,
    -- Msg 10793, Level 16, State 0, Line 1
    -- Both an index and a PRIMARY KEY constraint have been defined inline, with the definition of column 'MY_TABLE_ID', table 'dbo.MY_TABLE'.
    -- Defining both an index and a PRIMARY KEY constraint inline with the column definition is not allowed.
    INDEX IXUC_P_MY_SUPER_TABLE_S_SUFFIX UNIQUE CLUSTERED (P_MY_SUPER_TABLE_S_ID_5),

    -- Pattern: ^\[{Schema}\]\.\[{Table}\]\.\[IXNUNC_{Table}_{LATIN_UPPER_CASE}\]$
    -- Render:  ^\[dbo\]\.\[P_MY_SUPER_TABLE_S\]\.\[IXNUNC_P_MY_SUPER_TABLE_S_[A-Z][A-Z0-9_]+?\]$
    P_MY_SUPER_TABLE_S_ID_6   INT INDEX IXNUNC_P_MY_SUPER_TABLE_S_SUFFIX NONCLUSTERED,
    INDEX IXNUNC_P_MY_SUPER_TABLE_S_SUFFIX NONCLUSTERED (P_MY_SUPER_TABLE_S_ID_6),

    P_MY_SUPER_TABLE_S_ID_7   INT,
    -- It doesn't work:
    -- P_MY_SUPER_TABLE_S_ID_7 INT UNIQUE INDEX IXUNC_P_MY_SUPER_TABLE_S_SUFFIX NONCLUSTERED,
    INDEX IXUNC_P_MY_SUPER_TABLE_S_SUFFIX UNIQUE NONCLUSTERED (P_MY_SUPER_TABLE_S_ID_7),

    P_MY_SUPER_TABLE_S_ID_8   INT,
    INDEX CSC_P_MY_SUPER_TABLE_S_SUFFIX CLUSTERED COLUMNSTORE,

    P_MY_SUPER_TABLE_S_ID_9   INT,
    INDEX CSNC_P_MY_SUPER_TABLE_S_SUFFIX NONCLUSTERED COLUMNSTORE (P_MY_SUPER_TABLE_S_ID_9)
);
GO

CREATE PROCEDURE dbo.MyProc @SomeParameter VARCHAR(MAX)
AS
SELECT 'Hello World, ' + @SomeParameter;
GO

CREATE FUNCTION dbo.MyScalarFunc(@SomeParameter VARCHAR(MAX)) RETURNS VARCHAR(MAX)
AS
BEGIN
    RETURN 'Hello World, ' + @SomeParameter;
END