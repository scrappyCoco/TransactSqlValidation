CREATE PROCEDURE dbo.ExecStoredProcedure
AS
    -- Does not throw
    DECLARE @someUsefulValue INT = 123;

    EXEC #StoredProcedure @someUsefulValue;