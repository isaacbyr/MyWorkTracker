CREATE PROCEDURE [dbo].[spAdminSearchByEmployeeOrderTotal]
	@CompanyId INT,
	@OrderBy NVARCHAR(20),
	@Keyword NVARCHAR(40)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [u].FirstName, [u].LastName, [c].Job, [c].JobDate as 'Date', [c].[Location], [u].[Wage] , c.[Hours], c.[Subtotal] as 'Total' FROM [dbo].[User] as u
	FULL JOIN [dbo].[Employees] as e ON [u].Id = [e].EmployeeId
	FULL JOIN [dbo].[CalendarEntry] as c ON [u].Id = [c].UserId
	WHERE e.CompanyId = @CompanyId AND [u].FirstName LIKE @Keyword OR [u].LastName LIKE @Keyword
	ORDER BY
	CASE
		WHEN @OrderBy = 'Total (Asc)'
		THEN Total 
	END,
	CASE
		WHEN @OrderBy = 'Total (Desc)'
		THEN Total 
	END DESC
END;