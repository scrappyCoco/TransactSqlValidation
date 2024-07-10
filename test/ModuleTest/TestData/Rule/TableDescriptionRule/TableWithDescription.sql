-- Table and column have description and errors are not thrown.
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