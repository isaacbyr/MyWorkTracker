CREATE PROCEDURE [dbo].[spInsertRequest]
	@CompanyId INT,
	@UserId NVARCHAR(128),
	@Approved BIT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Requests] (CompanyId, UserId, Approved)
	VALUES (@CompanyId, @UserId, @Approved)
END
