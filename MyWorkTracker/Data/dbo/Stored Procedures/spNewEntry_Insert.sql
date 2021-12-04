CREATE PROCEDURE [dbo].[spNewEntry_Insert]
	@UserId NVARCHAR(128),
	@Job NVARCHAR(50),
	@Location NVARCHAR(50),
	@Wage MONEY,
	@Hours DECIMAL,
	@Subtotal MONEY,
	@Taxes MONEY,
	@Total MONEY,
	@Description NVARCHAR(150),
	@JobDate DATETIME2,
	@CalendarLocation NVARCHAR(5)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[CalendarEntry] (UserId, Job, Location, Wage, Hours, Subtotal, Taxes, Total, Description, JobDate, CalendarLocation)
	VALUES (@UserId, @Job, @Location, @Wage, @Hours, @Subtotal,@Taxes, @Total, @Description, @JobDate, @CalendarLocation)

END
