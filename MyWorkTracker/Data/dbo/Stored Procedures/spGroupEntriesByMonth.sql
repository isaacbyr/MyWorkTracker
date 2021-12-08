CREATE PROCEDURE [dbo].[spGroupEntriesByMonth]
@UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	select count(*) as 'Count', MONTH(JobDate) as 'Month', Sum(Total) as 'Total'
	from dbo.CalendarEntry
	WHERE UserId = @UserId
	group by Month(JobDate), Year(JobDate)
END
