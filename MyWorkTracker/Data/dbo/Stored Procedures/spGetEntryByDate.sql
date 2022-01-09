CREATE PROCEDURE [dbo].[spGetEntryByDate]
	@JobDate DATETIME2,
	@UserId NVARCHAR(128)
AS
BEGIN
SET NOCOUNT ON;
	SELECT Job, Location, Hours, Wage, Subtotal, Total, Description, JobDate, UserId, StartTime, EndTime
	FROM [dbo].[CalendarEntry]
	WHERE JobDate = @JobDate AND UserId = @UserId
END
