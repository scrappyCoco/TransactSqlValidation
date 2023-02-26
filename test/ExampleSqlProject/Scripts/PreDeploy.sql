:ON error EXIT
GO

:setvar DatabaseName "ExampleSqlProject"

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL)
    BEGIN
        RAISERROR ('Database already exists', 16, 1)
    END

GO