CREATE PROCEDURE [dbo].[spGroupEntriesByDay]
	@UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Total, JobDate as 'Date' 
	FROM dbo.CalendarEntry
	WHERE UserId = @UserId
	ORDER BY Date
END
