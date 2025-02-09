CREATE PROCEDURE dbo.WhileStatement
AS
    DECLARE @i INT = 1;

    WHILE @i <= 10
    BEGIN
        SET @i += 1;
    END