CREATE PROCEDURE dbo.ReturnStatement
AS
    DECLARE @i INT = 1;
    -- Does not throw.
    RETURN @i;