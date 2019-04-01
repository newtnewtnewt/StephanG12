USE master
GO

IF DB_ID('Apps') IS NOT NULL
    DROP DATABASE Apps
GO

/****** Object:  Database Apps    ******/
CREATE DATABASE Apps
GO

USE Apps
GO

CREATE TABLE ApplicationInfo(
    appName             VARCHAR(50)     NOT NULL,
    username		    VARCHAR(50)     NOT NULL, 
    appTotalScore       INT             DEFAULT 0,
    appRating           INT             DEFAULT 0,
    numberOfReviews     INT             DEFAULT 0
)
GO

CREATE TABLE users (
    usrID           int IDENTITY(1,1)       NOT NULL,
	usrLast         VARCHAR(50)            NULL,
	usrFirst        VARCHAR(50)            NULL,
    username        VARCHAR(50)             NOT NULL
)
GO

CREATE TABLE review (
	reviewID			int IDENTITY(1,1)	NOT NULL,
	username			VARCHAR(50)			NOT NULL,
	appName				VARCHAR(50)			NOT NULL,
	appRating           INT					DEFAULT 0,
)
GO

CREATE TABLE ApplicationList(
	appID			int IDENTITY(1,1)		NOT NULL,
	appName         VARCHAR(50)				NOT NULL
)
GO

CREATE PROCEDURE addApp @appName VARCHAR(50), @username VARCHAR(50)
AS
INSERT ApplicationInfo VALUES 
(@appName, @username,0,0,0)
INSERT dbo.ApplicationList VALUES
(@appName)
GO

CREATE PROCEDURE addUser @usrLast VARCHAR(50),  @usrFirst VARCHAR(50), @username VARCHAR(50)
AS
INSERT users VALUES 
(@usrLast, @usrFirst, @username)
GO

CREATE PROCEDURE addReview @username VARCHAR(50),  @appName VARCHAR(50), @appRating INT
AS
INSERT review VALUES 
(@username, @appName, @appRating)
GO

