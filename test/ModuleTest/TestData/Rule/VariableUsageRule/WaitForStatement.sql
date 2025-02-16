CREATE PROCEDURE dbo.WaitForStatement
AS
    DECLARE @Delay1 CHAR(8) = '00:00:02';
    WAITFOR DELAY @Delay1;