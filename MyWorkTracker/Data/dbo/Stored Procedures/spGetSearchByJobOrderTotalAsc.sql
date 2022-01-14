CREATE PROCEDURE [dbo].[spGetSearchByJobOrderTotalAsc]
	@UserId NVARCHAR(128),
	@Keyword NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT c.Job, c.[Location], c.[JobDate] as 'Date', c.Wage, c.[Hours], c.Subtotal 
	FROM [dbo].[CalendarEntry] AS [c]
	FULL JOIN [dbo].[User] as [u] ON [u].Id = [c].UserId
	WHERE [c].UserId = @UserId AND c.Job LIKE @Keyword
	ORDER BY c.Subtotal 
END
