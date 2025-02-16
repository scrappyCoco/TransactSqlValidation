CREATE PROCEDURE dbo.ThrowStatement
AS
    DECLARE @msg NVARCHAR(2048) = 'Something goes wrong';
    THROW 60000, @msg, 1;