CREATE PROCEDURE [dbo].[spGetEntryByDate]
	@JobDate NVARCHAR(20)
AS
BEGIN
SET NOCOUNT ON;
	SELECT Job, Location, Hours, Wage, Subtotal, Total, Taxes, Description, JobDate
	FROM [dbo].[CalendarEntry]
	WHERE JobDate = @JobDate
END
