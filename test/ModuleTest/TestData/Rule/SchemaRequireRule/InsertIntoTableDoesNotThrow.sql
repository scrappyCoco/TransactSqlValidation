CREATE PROCEDURE dbo.InsertIntoTableDoesNotThrow
AS
BEGIN
    INSERT INTO Production.Product (Style)
    SELECT 'W';
END