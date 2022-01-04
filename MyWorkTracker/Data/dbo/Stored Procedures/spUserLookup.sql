CREATE PROCEDURE [dbo].[spUserLookup]
	@Id NVARCHAR(128)
AS
begin
	set nocount on;

	SELECT Id, FirstName, LastName, Email, Company, IsAdmin
	FROM [dbo].[User]
	WHERE Id = @Id;
end
