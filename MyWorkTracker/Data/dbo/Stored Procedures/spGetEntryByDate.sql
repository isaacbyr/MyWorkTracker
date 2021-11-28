CREATE PROCEDURE [dbo].[spGetEntryByDate]
	@JobDate NVARCHAR(20),
	@UserId NVARCHAR(128)
AS
BEGIN
SET NOCOUNT ON;
	SELECT Job, Location, Hours, Wage, Subtotal, Total, Taxes, Description, JobDate, UserId
	FROM [dbo].[CalendarEntry]
	WHERE JobDate = @JobDate AND UserId = @UserId
END
