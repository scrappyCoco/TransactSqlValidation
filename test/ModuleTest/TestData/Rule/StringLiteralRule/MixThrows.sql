CREATE PROCEDURE dbo.MixThrows
AS
BEGIN
    -- Expected error message: SR1001 : Coding4Fun : 'КириллицаLatin' has invalid value
    DECLARE @str NVARCHAR(100) = N'КириллицаLatin';
END