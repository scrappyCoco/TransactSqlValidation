CREATE PROCEDURE dbo.DeleteAliasDoesNotThrow
AS
BEGIN
    DELETE p
    FROM Production.Product AS p
    WHERE Style IS NULL;
END