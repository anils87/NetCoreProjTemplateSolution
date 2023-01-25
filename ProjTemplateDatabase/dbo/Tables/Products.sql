CREATE TABLE [dbo].[Products]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductName] VARCHAR(250) NOT NULL,
	[CategoryId] INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	[Price] DECIMAL(18,9) NOT NULL,
	[IsActive] INT NOT NULL,
	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL,
	[ModifiedBy] INT,
	[ModifiedDate] DATETIME
)
