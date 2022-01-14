CREATE PROCEDURE [dbo].[spUpdateEntry]
	@UserId NVARCHAR(128),
	@Job NVARCHAR(50),
	@Location NVARCHAR(50),
	@Wage MONEY,
	@Hours DECIMAL,
	@Subtotal MONEY,
	@Total MONEY,
	@Description NVARCHAR(150),
	@JobDate DATETIME2,
	@StartTime NVARCHAR(10),
	@EndTime NVARCHAR(10)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[CalendarEntry] 
	SET Job = @Job, [Location] = @Location, Wage = @Wage, [Hours] = @Hours, Subtotal = @Subtotal, Total = @Total,
	[Description] = @Description, StartTime = @StartTime, EndTime = @EndTime
	WHERE UserId = @UserId AND JobDate = @JobDate
END
