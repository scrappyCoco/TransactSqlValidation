CREATE PROCEDURE dbo.InsideCteDoesNotThrow
AS
BEGIN
    DECLARE @styles TABLE (Style NCHAR(2));
    
    WITH Styles AS (
        SELECT Style
        FROM Production.Product
        GROUP BY Style
    )
    INSERT INTO @styles (Style)
    SELECT Style
    FROM Styles;
END