CREATE PROCEDURE [dbo].[sp_InvalidIdentifierPath] @param1 int = 0,
                                               @param2 int
AS
BEGIN
    -- Coding4fun.SR1001 : 'MixСлов' has invalid value
    DECLARE @str NVARCHAR(50) = N'MixСлов';
    
    -- Valid:
    SET @str = N'ValidWord';
    SET @str = N'ИлиТак';

    -- Coding4fun.SR1002 : Object name must include [schema_name] and [object_name], but was: MY_TABLE.
    SELECT 1 FROM MY_TABLE;

    -- Valid object path: [schema_name].[object_name].
    SELECT 1 FROM dbo.MY_TABLE;
END