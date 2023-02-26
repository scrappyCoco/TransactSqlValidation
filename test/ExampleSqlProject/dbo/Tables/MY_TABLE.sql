CREATE TABLE [dbo].[MY_TABLE]
(
    [MY_TABLE_ID] INT NOT NULL PRIMARY KEY
)
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description'
    , @value = 'TABLE'
    , @level0type = N'SCHEMA'
    , @level0name = N'dbo'
    , @level1type = N'TABLE'
    , @level1name = N'MY_TABLE';
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description'
    , @value = 'ID'
    , @level0type = N'SCHEMA'
    , @level0name = N'dbo'
    , @level1type = N'TABLE'
    , @level1name = N'MY_TABLE'
    , @level2type = N'COLUMN'
    , @level2name = N'MY_TABLE_ID';
GO