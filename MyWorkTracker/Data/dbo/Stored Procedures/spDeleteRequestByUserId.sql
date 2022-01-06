CREATE PROCEDURE [dbo].[spDeleteRequestByUserId]
	@UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[Requests] 
	WHERE UserId = @UserId
END
