CREATE PROCEDURE dbo.UpdateStatement
AS
    DECLARE @i INT = 1;

    UPDATE #T
    SET C = @i;