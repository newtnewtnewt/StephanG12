DROP TABLE dbo.CommentsTable
CREATE TABLE [dbo].[CommentsTable] (
    [reviewID]    INT           IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [username]    VARCHAR (50)  NOT NULL,
    [appID]     INT NOT NULL,
    [appRating]   INT           DEFAULT ((1)) NULL,
    [commentText] VARCHAR (MAX) NULL,
);

DROP TABLE [dbo].[AppTable]
CREATE TABLE [dbo].[AppTable]
(
	appID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	Description VARCHAR(MAX) NOT NULL,
	Organization VARCHAR(50) NOT NULL, 
	[Platform(s)] VARCHAR(50) NOT NULL, 
	[Version(s)] VARCHAR(50) NOT NULL,
	Rating int NOT NULL,
	[View Comments] VARCHAR(50) NOT NULL
)


