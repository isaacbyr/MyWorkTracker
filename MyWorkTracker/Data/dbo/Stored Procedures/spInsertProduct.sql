CREATE PROCEDURE [dbo].[spInsertProduct]
	@CompanyId INT,
	@Date DATETIME2,
	@ProductName NVARCHAR(40),
	@RetailPrice MONEY,
	@PurchasePrice MONEY,
	@Job NVARCHAR(40),
	@Quantity INT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Product] (CompanyId, [Date], [ProductName], [RetailPrice], [PurchasePrice], [Job], [Quantity])
	VALUES (@CompanyId, @Date, @ProductName, @RetailPrice, @PurchasePrice, @Job, @Quantity)
END
