CREATE PROCEDURE [dbo].[spApproveUser]
	@Id NVARCHAR(128),
	@Company NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[User] 
	SET IsApproved = '1', Company = @Company
	WHERE Id = @Id
END