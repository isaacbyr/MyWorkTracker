CREATE PROCEDURE [dbo].[spGetRequests]
	@CompanyId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [u].Id, [u].FirstName as 'ReqFirstName', [u].LastName as 'ReqLastName' FROM dbo.[User] as u
	INNER JOIN dbo.Requests r ON [u].Id = [r].UserId
	WHERE [r].CompanyId= @CompanyId
END
