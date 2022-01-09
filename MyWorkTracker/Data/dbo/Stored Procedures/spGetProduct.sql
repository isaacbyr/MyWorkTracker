CREATE PROCEDURE [dbo].[spGetProduct]
	@CompanyId INT,
	@Date DATETIME2
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Product]
	WHERE CompanyId = @CompanyId AND [Date] = @Date
END
