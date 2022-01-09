CREATE PROCEDURE [dbo].[spGetCompanyId]
	@UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id FROM [dbo].[Company]
	WHERE OwnerId = @UserId
END
