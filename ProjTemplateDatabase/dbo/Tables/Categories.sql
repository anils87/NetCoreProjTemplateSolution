CREATE TABLE [dbo].[Categories]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(250) NOT NULL,
	[IsActive] INT NOT NULL,
	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL,
	[ModifiedBy] INT,
	[ModifiedDate] DATETIME
)
