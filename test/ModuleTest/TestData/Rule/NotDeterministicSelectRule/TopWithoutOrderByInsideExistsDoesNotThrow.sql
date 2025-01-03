CREATE PROCEDURE dbo.TopWithoutOrderByInsideExistsDoesNotThrow
AS
    IF NOT EXISTS(
        SELECT TOP (1) fg.name
        FROM sys.filegroups fg
        WHERE fg.name = ''
    )
    BEGIN
        PRINT '';
    END