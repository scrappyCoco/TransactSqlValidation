CREATE PROCEDURE dbo.SelectScalarFunction
AS
    -- Does not throw
    DECLARE @someUsefulValue INT = 123;

    SELECT #ScalarFunction(@someUsefulValue);