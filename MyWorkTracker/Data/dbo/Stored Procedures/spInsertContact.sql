CREATE PROCEDURE [dbo].[spInsertContact]
	@CompanyId INT,
	@FirstName NVARCHAR(40),
	@LastName NVARCHAR(40),
	@Email NVARCHAR(50),
	@PhoneNumber NVARCHAR(20),
	@Address NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Contacts] (CompanyId, FirstName, LastName, Email, PhoneNumber, [Address])
	VALUES (@CompanyId, @FirstName, @LastName, @Email, @PhoneNumber, @Address)
END
