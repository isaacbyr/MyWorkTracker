CREATE PROCEDURE [dbo].[spGroupEntriesByDay]
	@UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Total, JobDate as 'Date' 
	FROM dbo.CalendarEntry
	ORDER BY Date
END
