-- Expected error message: SR1004 : Coding4fun : Table 'MY_TABLE' doesn't contain a description
CREATE TABLE [dbo].[MY_TABLE]
(
    -- Expected error message: SR1004 : Coding4fun : Column 'MY_TABLE_ID' doesn't contain a description
    [MY_TABLE_ID] INT NOT NULL PRIMARY KEY
)
GO