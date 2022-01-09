CREATE PROCEDURE [dbo].[spDeleteProductById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[Product]
	WHERE Id = @Id
END
