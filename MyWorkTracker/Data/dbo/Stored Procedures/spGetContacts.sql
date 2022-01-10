CREATE PROCEDURE [dbo].[spGetContacts]
	@CompanyId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [dbo].[Contacts]
	WHERE CompanyId = @CompanyId
END
