-- Coding4fun.ObjectName.Function
-- Pattern: \[{Schema}\]\.\[{LatinPascalCase}\]
-- Render:  \[dbo\]\.\[[A-Z][A-Za-z0-9]+?\]
CREATE FUNCTION dbo.MyScalarFunc(@SomeParameter VARCHAR(MAX)) RETURNS VARCHAR(MAX)
AS
BEGIN
RETURN 'Hello World, ' + @SomeParameter;
END