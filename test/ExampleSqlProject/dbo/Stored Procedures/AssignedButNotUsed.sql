CREATE PROCEDURE dbo.AssignedButNotUsed
AS
    -- Expected error message: SR1006 : Coding4Fun : Variable '@someUsefulValue' is defined, but was newer used
    DECLARE @someUsefulValue INT = 123;

    CREATE TABLE #MY_TABLE (ID INT);

    -- It writes to variable
    SELECT @someUsefulValue = 1
    FROM #MY_TABLE;

    SET @someUsefulValue = 321;