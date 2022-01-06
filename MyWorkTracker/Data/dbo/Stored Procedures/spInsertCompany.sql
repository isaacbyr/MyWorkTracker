CREATE PROCEDURE [dbo].[spInsertCompany]
	@Id INT OUTPUT,
	@Name NVARCHAR(50),
	@OwnerId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Company] (OwnerId, [Name])
	VALUES (@OwnerId, @Name)
END
