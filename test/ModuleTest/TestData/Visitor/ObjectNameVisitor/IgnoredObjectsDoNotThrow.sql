CREATE TABLE [import].[Выписка]
(
    [Идентификатор] INT  NOT NULL,
    [Дата]          DATE NULL,
    CONSTRAINT [PK_Выписка] PRIMARY KEY CLUSTERED ([Идентификатор] ASC)
);