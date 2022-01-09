CREATE PROCEDURE [dbo].[spGetEmployeeById]
	@Id NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, FirstName, LastName, Wage, BilledOut, CreatedAt
	FROM [dbo].[User]
	WHERE Id = @Id
END
