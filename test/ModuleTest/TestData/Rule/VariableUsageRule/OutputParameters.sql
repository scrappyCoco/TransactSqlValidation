CREATE PROCEDURE dbo.OutputParameters @publicParameters INT OUTPUT
AS
BEGIN
    SET @publicParameters = 1;
    PRINT 'Output parameter is not used inside this routine, might it used in a caller.';
END