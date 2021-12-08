CREATE PROCEDURE [dbo].[spGetHoursPerDay]
	@UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Hours, Jobdate as 'Date'
	FROM dbo.CalendarEntry
	WHERE @UserId = UserId
	ORDER BY Date

END