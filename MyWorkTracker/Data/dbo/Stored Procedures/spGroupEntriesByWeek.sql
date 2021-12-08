CREATE PROCEDURE [dbo].[spGroupEntriesByWeek]
@UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	select count(*) as 'Count', DatePart(week, JobDate) as 'Week', Sum(Total) as 'Total'
	from dbo.CalendarEntry
	WHERE UserId = @UserId
	group by DatePart(week, JobDate)
END
