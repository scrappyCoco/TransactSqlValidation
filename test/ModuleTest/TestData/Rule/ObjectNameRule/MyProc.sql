-- Coding4fun.ObjectName.Procedure
-- Pattern: \[{Schema}\]\.\[{LatinPascalCase}\]
-- Render:  \[dbo\]\.\[[A-Z][A-Za-z0-9]+?\]
--
-- Coding4fun.ObjectName.RoutineParameter
-- Pattern: \[{Schema}\]\.\[{LatinPascalCase}\]\.\[@{LatinPascalCase}\]
-- Render:  \[{Schema}\]\.\[[A-Z][A-Za-z0-9]+?\]\.\[@[A-Z][A-Za-z0-9]+?\]
CREATE PROCEDURE dbo.MyProc @SomeParameter VARCHAR(MAX)
AS
SELECT 'Hello World, ' + @SomeParameter;
GO