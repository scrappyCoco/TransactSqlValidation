/*
Описание процесса удаления таблиц находиться
https://wiki.yooteam.ru/pages/viewpage.action?pageId=286601784
*/

DECLARE @POSTFIX VARCHAR(30) = '_FOR_TRUNCATE'

IF OBJECT_ID('dbo.__VERSION') IS NOT NULL
    BEGIN
        PRINT 'Удаление данных из старых таблиц с постфиксом ' + @POSTFIX

        --Вычисляем устанавливаемую версию, т.к. обновление версии происходит в самом конце, для этого прибавляем 1 к версии
        DECLARE @MAXVER BIGINT = (SELECT TOP 1 VERSION_ID FROM dbo.__VERSION ORDER BY VERSION_ID DESC)
        DECLARE
            @A BIGINT = (SELECT RIGHT(CAST(@MAXVER AS VARCHAR(9)), 3))
            ,@B BIGINT = (SELECT SUBSTRING(RIGHT(CAST(@MAXVER AS VARCHAR(9)), 6), 1, 3))
            ,@C BIGINT = (SELECT LEFT(CAST(@MAXVER AS VARCHAR(9)), (LEN(CAST(@MAXVER AS VARCHAR(9))) - 6)))

        SELECT @A = @A + 1
        IF @A = 100
            SELECT @A = 0, @B = @B + 1
        IF @B >= 100
            SELECT @B = 0, @C = @C + 1

        SELECT @MAXVER = CAST((CAST(@C AS VARCHAR(9)) + RIGHT('00' + CAST(@B AS VARCHAR(2)), 3) +
                               RIGHT('00' + CAST(@A AS VARCHAR(2)), 3)) AS BIGINT)
        DECLARE @MAXVER_STR VARCHAR(20) = (CAST(@C AS VARCHAR(9)) + '.' + CAST(@B AS VARCHAR(2)) + '.' +
                                           CAST(@A AS VARCHAR(2)))
        --Конец вычисления устанавливаемой версии

        DECLARE @TRUNC_TABLE TABLE
                             (
                                 TRUNC_TABLE_ID                        INT IDENTITY (1, 1),
                                 TRUNC_TABLE_SQL                       VARCHAR(MAX) NOT NULL --скрипт отчистки версии
                                 ,
                                 TRUNC_TABLE_RELEASE_VERSION_ID        BIGINT       NOT NULL --версия в которой были проведены последние изменения в таблице
                                 ,
                                 TRUNC_TABLE_RELEASE_VERSION_FOR_TRUNC BIGINT       NULL     -- версия с которой можно проводить отчистку данных
                             )

        /*
        Находим все таблицы для отчистки
        условия:
            1. Таблица должна быть изменена в релизах
            2. не должна быть temporal_type > 0
            3. переименование таблицы должно быть не сегодня
        */
        INSERT INTO @TRUNC_TABLE( TRUNC_TABLE_SQL
                                , TRUNC_TABLE_RELEASE_VERSION_ID
                                , TRUNC_TABLE_RELEASE_VERSION_FOR_TRUNC)
        SELECT 'IF (OBJECT_ID(''' + s.name + '.' + t.name + ''') IS NOT NULL
        AND EXISTS(SELECT TOP 1 1 FROM ' + s.name + '.' + t.name + '))
            TRUNCATE TABLE ' + s.name + '.' + t.name
             , (SELECT MIN(v.VERSION_ID)
                FROM dbo.__VERSION v
                WHERE v.UPDATE_TIME >= t.modify_date) --дата установки релиза больше или равна даты изменения таблицы
             , CASE
                   WHEN CHARINDEX(@POSTFIX + '_', t.name) = 0 THEN @MAXVER
                   ELSE v.VERSION_ID
            END
        FROM sys.tables t
                 INNER JOIN
             sys.schemas s
             ON t.schema_id = s.schema_id
                 AND t.name like '%' + @POSTFIX + '%'
                 AND t.temporal_type = 0 --только нормальные таблицы
                 AND t.modify_date <
                     CAST(GETDATE() AS DATE) --нельзя чистить сразу, надо подождать наступления следующего дня
                 LEFT JOIN
             (SELECT VERSION, VERSION_ID
              FROM dbo.__VERSION
              UNION ALL
              SELECT @MAXVER_STR, @MAXVER) v
             ON v.VERSION =
                REPLACE(SUBSTRING(t.name, CHARINDEX(@POSTFIX + '_', t.name) + LEN(@POSTFIX + '_'), LEN(t.name)), '_',
                        '.')
        WHERE (SELECT MIN(v.VERSION_ID) FROM dbo.__VERSION v WHERE v.UPDATE_TIME >= t.modify_date) IS NOT NULL

        --Удаляем из таблицы все таблицы предназначенные для удаления в будущих релизах
        DELETE
        FROM @TRUNC_TABLE
        WHERE TRUNC_TABLE_RELEASE_VERSION_FOR_TRUNC > @MAXVER
           OR TRUNC_TABLE_RELEASE_VERSION_FOR_TRUNC IS NULL

        --Собственно отчистка данных
        DECLARE @ID INT, @SQL VARCHAR(MAX)
        WHILE (EXISTS(SELECT TOP 1 1 FROM @TRUNC_TABLE))
            BEGIN
                SELECT TOP 1 @ID = TRUNC_TABLE_ID, @SQL = TRUNC_TABLE_SQL FROM @TRUNC_TABLE
                EXEC (@SQL)
                DELETE FROM @TRUNC_TABLE WHERE TRUNC_TABLE_ID = @ID
            END

        PRINT 'Конец удаление данных из старых таблиц с постфиксом ' + @POSTFIX
    END
