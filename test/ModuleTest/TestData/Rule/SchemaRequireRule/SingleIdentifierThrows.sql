CREATE PROCEDURE dbo.SingleIdentifierThrows
AS
BEGIN
    -- Expected error message: SR1002 : Coding4Fun : Object name must consists from [schema_name] and [object_name], but was: Product 
    SELECT Style
    FROM Product;
END