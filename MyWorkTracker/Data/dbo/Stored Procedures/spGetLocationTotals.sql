CREATE PROCEDURE [dbo].[spGetLocationTotals]
	@UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Location, Sum(Total) as 'Total'
	FROM dbo.CalendarEntry
	WHERE UserId = @UserId
	GROUP BY Location
END
