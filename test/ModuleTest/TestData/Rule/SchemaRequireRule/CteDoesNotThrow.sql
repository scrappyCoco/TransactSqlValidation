CREATE PROCEDURE dbo.CteDoesNotThrow
AS
BEGIN
    ;WITH Styles (Style, Count) AS (
        SELECT Style, COUNT(*) AS Count
        FROM Production.Product
        GROUP BY Style
    )
    SELECT Style, COUNT(*)
    FROM Styles
END