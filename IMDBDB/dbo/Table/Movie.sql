CREATE TABLE [dbo].[Movie]
(
	[Id-Movie] INT NOT NULL PRIMARY KEY, 
    [OriginaTitle] NVARCHAR(50) NOT NULL, 
    [ReleaseDate] DATETIME NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL
)
