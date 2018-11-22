CREATE TABLE [dbo].[Movie]
(
	[Id_Movie] INT IDENTITY NOT NULL PRIMARY KEY, 
    [OriginalTitle] NVARCHAR(50) NOT NULL, 
    [ReleaseDate] DATETIME NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL
)
