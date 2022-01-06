CREATE PROCEDURE [dbo].[spGetCompanyInfo]
	@OwnerId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Company] WHERE OwnerId = @OwnerId
END
