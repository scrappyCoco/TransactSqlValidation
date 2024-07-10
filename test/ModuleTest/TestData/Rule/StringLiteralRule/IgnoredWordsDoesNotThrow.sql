CREATE PROCEDURE dbo.IgnoredWordsDoesNotThrow
AS
BEGIN
    -- Coding4Fun.IgnoreWordValidation: ThisIsInvalidЗначение
    DECLARE @str NVARCHAR(100) = N'ThisIsInvalidЗначение';
END