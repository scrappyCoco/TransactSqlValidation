CREATE PROCEDURE dbo.DeleteTableThrows
AS
BEGIN
    -- Expected error message: SR1002 : Coding4Fun : Object name must consists from [schema_name] and [object_name], but was: Product 
    DELETE Product
    WHERE Style IS NULL;
END