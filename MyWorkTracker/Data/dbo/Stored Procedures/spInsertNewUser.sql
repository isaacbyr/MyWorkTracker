CREATE PROCEDURE [dbo].[spInsertNewUser]
	@Id NVARCHAR(128),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Company NVARCHAR(50),
	@Email NVARCHAR(256),
	@IsAdmin BIT,
	@IsApproved BIT,
	@CreatedAt DATETIME2
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[User] (Id, FirstName, LastName, Email, Company, IsAdmin, IsApproved, CreatedAt)
	VALUES (@Id, @FirstName, @LastName, @Email, @Company, @IsAdmin, @IsApproved, @CreatedAt)
END
