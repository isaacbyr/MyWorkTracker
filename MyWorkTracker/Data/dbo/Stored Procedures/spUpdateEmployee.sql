CREATE PROCEDURE [dbo].[spUpdateEmployee]
	@Id NVARCHAR(128),
	@Wage DECIMAL,
	@BilledOut DECIMAL
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[User]
	SET Wage = @Wage, BilledOut = @BilledOut
	WHERE Id = @Id
END
