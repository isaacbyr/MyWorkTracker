CREATE PROCEDURE [dbo].[spApproveUser]
	@Id NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[User] 
	SET IsApproved = '1'
	WHERE Id = @Id
END