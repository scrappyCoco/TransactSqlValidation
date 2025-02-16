CREATE PROCEDURE dbo.SelectTableValuedFunction
AS
    -- Does not throw
    DECLARE @someUsefulValue INT = 123;

    SELECT Val
    FROM #TableValuedFunction(@someUsefulValue);