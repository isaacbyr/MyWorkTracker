CREATE PROCEDURE [dbo].[spLoadOwnerInfo]
	@CompanyId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [u].Id, [u].FirstName, [u].LastName FROM [dbo].[User] as [u]
	FULL JOIN [dbo].[Company] AS [c] ON [u].Id = [c].OwnerId
	WHERE [c].Id = @CompanyId
END

