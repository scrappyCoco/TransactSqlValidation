CREATE PROCEDURE dbo.SetVariableStatement
AS
    DECLARE @a INT = 1, @b INT;
    -- Does not throw.
    SET @b = @a;
    RETURN @b;