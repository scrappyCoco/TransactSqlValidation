-- Expected error message: SR1004 : Coding4Fun : Table 'TableWithoutDescription' doesn't contain a description
CREATE TABLE [dbo].[TableWithoutDescription]
(
    -- Expected error message: SR1004 : Coding4Fun : Column 'ID' doesn't contain a description
    [ID] INT NOT NULL PRIMARY KEY
)
GO