CREATE PROCEDURE dbo.InsertStatement
AS
    DECLARE @i INT = 1;

    INSERT INTO #T (C)
    VALUES (@i);