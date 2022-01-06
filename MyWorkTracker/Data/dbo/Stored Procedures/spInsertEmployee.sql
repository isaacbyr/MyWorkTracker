CREATE PROCEDURE [dbo].[spInsertEmployee]
	@CompanyId INT,
	@EmployeeId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Employees] (CompanyId, EmployeeId)
	VALUES (@CompanyId, @EmployeeId)
END
