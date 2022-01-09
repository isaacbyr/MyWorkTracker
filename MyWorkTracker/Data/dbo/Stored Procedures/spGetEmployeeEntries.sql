CREATE PROCEDURE [dbo].[spGetEmployeeEntries]
	@JobDate DATETIME2,
	@CompanyId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT FirstName, LastName, Job, [Location], StartTime, EndTime, [u].[Wage], [u].[BilledOut] , [Hours], [Subtotal]  FROM [dbo].[User] as u
	FULL JOIN [dbo].[Employees] as e ON [u].Id = [e].EmployeeId
	FULL JOIN [dbo].[CalendarEntry] as c ON [u].Id = [c].UserId
	WHERE e.CompanyId = @CompanyId  AND c.JobDate  = @JobDate 
END
