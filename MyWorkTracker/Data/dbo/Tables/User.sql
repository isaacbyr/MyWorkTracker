CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY,
    [FirstName]            NVARCHAR (50)  NOT NULL,
    [LastName]             NVARCHAR (50)  NOT NULL,
    [Company]              NVARCHAR (50)  NOT NULL DEFAULT 'No Company',
    [IsAdmin]              BIT  NOT NULL,
    [IsApproved]           BIT NOT NULL DEFAULT 0,
	[Email]                NVARCHAR(256) NOT NULL,
    [Wage]                 MONEY NOT NULL DEFAULT 0,
    [BilledOut]            MONEY NOT NULL DEFAULT 0,
	[CreatedAt]            DATETIME2 NOT NULL DEFAULT getutcdate()
)
