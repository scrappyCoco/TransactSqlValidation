CREATE PROCEDURE dbo.IdentifierWithSchemaDoesNotThrow
AS
BEGIN
    SELECT Style
    FROM Production.Product;
END