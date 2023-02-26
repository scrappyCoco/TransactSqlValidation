/*
Расскоментировать не ранее релиза 0.0.3

--Создаем роль для сотрудников департамента
CREATE ROLE [Developer]
    AUTHORIZATION [dbo];
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Роль для сотрудников департамента аналитических сервисов',
    @level0type=N'USER',
    @level0name=N'Developer'
GO

--Даем право читать данные
GRANT SELECT
    ON SCHEMA::[dbo] TO [Developer];
GO
*/