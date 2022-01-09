﻿CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CompanyId] INT NOT NULL,
	[Date] DATETIME2 NOT NULL,
	[ProductName] NVARCHAR(40) NOT NULL,
	[PurchasePrice] MONEY NOT NULL,
	[RetailPrice] MONEY NOT NULL,
	[Quantity] INT NOT NULL,
	[Job] NVARCHAR(40)
)
