CREATE PROCEDURE [dbo].[spUserLookup]
	@Id NVARCHAR(128)
AS
begin
	set nocount on;

	SELECT Id, FirstName, LastName, EmailAddress
	FROM [dbo].[User]
	WHERE Id = @Id;
end
