CREATE PROCEDURE dbo.DeclareVariableStatement
AS
    DECLARE @a INT = 1;
    -- It does not throw.
    DECLARE @b INT = @a;

    SELECT @b;