CREATE PROCEDURE dbo.TopWithoutOrderByThrows
AS
    -- Expected error message: SR1005 : Coding4Fun : TOP (N) requires ORDER BY clause
    SELECT TOP (1) 1
    FROM #T;