CREATE PROCEDURE [dbo].[delSiteConfig]
	@Id INT
AS
BEGIN
    DELETE FROM SiteConfig WHERE Id = @Id;
END;