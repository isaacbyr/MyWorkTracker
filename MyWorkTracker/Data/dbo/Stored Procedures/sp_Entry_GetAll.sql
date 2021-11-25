CREATE PROCEDURE [dbo].[sp_Entry_GetAll]
AS
BEGIN
SET NOCOUNT ON;
	SELECT Job, Location, Hours, Wage, Subtotal, Total, Taxes, Description
	FROM [dbo].[CalendarEntry]
	ORDER BY Id
END
