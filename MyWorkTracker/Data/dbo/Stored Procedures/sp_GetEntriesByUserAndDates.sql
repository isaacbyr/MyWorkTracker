CREATE PROCEDURE [dbo].[spGetEntriesByUserAndDates]
	@UserId NVARCHAR(128),
	@FirstDate DATETIME2,
	@LastDate DATETIME2
AS
BEGIN
SET NOCOUNT ON;
	SELECT Job, Location, Hours, Wage, Subtotal, Total, Taxes, Description, JobDate, UserId, CalendarLocation
	FROM [dbo].[CalendarEntry]
	WHERE (JobDate BETWEEN @FirstDate AND @LastDate) AND UserId = @UserId
END
