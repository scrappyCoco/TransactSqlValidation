CREATE PROCEDURE dbo.IfExpression
AS
    DECLARE @someUsefulValue INT = 123;

    IF (@someUsefulValue = 123) PRINT 'The variable is used.';