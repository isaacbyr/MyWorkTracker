CREATE PROCEDURE [dbo].[spGetEntriesByUserId]
	@UserId NVARCHAR(128)
AS
BEGIN
SET NOCOUNT ON;
	SELECT Job, Location, Hours, Wage, Subtotal, Total, Description, JobDate, UserId
	FROM [dbo].[CalendarEntry]
	WHERE UserId = @UserId
END
