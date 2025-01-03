CREATE PROCEDURE dbo.TopWithOrderByDoesNotThrow
AS
    SELECT TOP (1) A
    FROM #T
    ORDER BY A;