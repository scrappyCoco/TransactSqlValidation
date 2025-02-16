CREATE PROCEDURE dbo.DeleteStatement
AS
    DECLARE @i INT = 1;

    DELETE #T
    WHERE C = @i;