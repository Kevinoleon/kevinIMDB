CREATE TABLE [dbo].[Role]
(
	[Id-Role] INT NOT NULL PRIMARY KEY, 
    [Id-Movie] INT NOT NULL, 
    [Id-Actor] INT NOT NULL, 
    [Name] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Role_Actor] FOREIGN KEY ([Id-Actor]) REFERENCES [Actor]([Id-Actor]), 
    CONSTRAINT [FK_Role_Movie] FOREIGN KEY ([Id-Movie]) REFERENCES [Movie]([Id-Movie])
)
