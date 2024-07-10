CREATE PROCEDURE dbo.UpdateAliasDoesNotThrow
AS
BEGIN
    UPDATE p
    SET p.Style = 'M'
    FROM Product.Production AS p
    WHERE p.Style IS NULL;
END