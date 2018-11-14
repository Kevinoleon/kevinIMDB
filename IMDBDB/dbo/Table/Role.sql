CREATE TABLE [dbo].[Role] (
    [Id-Role]  INT        NOT NULL,
    [Id-Movie] INT        NOT NULL,
    [Id-Actor] INT        NOT NULL,
    [Name]     NVARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id-Role] ASC),
    CONSTRAINT [FK_Role_Actor] FOREIGN KEY ([Id-Actor]) REFERENCES [dbo].[Actor] ([Id-Actor]),
    CONSTRAINT [FK_Role_Movie] FOREIGN KEY ([Id-Movie]) REFERENCES [dbo].[Movie] ([Id-Movie])
);

