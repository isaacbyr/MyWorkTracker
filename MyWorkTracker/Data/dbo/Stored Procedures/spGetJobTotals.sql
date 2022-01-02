CREATE PROCEDURE [dbo].[spGetJobTotals]
	@UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Job, Sum(Total) as 'Total'
	FROM dbo.CalendarEntry
	WHERE UserId = @UserId
	GROUP BY Job
END
