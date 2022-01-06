CREATE PROCEDURE [dbo].[spGetEmployees]
	@CompanyId INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT [u].FirstName, [u].LastName FROM [dbo].[User] as u
	INNER JOIN [dbo].[Employees] as e ON [u].Id = [e].EmployeeId
	WHERE e.CompanyId = @CompanyId
END
