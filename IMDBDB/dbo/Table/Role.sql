CREATE TABLE [dbo].[Role] (
    [Id_Role]  INT IDENTITY  NOT NULL,
    [Id_Movie] INT        NOT NULL,
    [Id_Actor] INT        NOT NULL,
    [Name]     NVARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Role] ASC),
    CONSTRAINT [FK_Role_Actor] FOREIGN KEY ([Id_Actor]) REFERENCES [dbo].[Actor] ([Id_Actor]),
    CONSTRAINT [FK_Role_Movie] FOREIGN KEY ([Id_Movie]) REFERENCES [dbo].[Movie] ([Id_Movie])
);

