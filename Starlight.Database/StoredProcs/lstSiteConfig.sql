CREATE PROCEDURE [dbo].[lstSiteConfig]
AS
BEGIN
    SELECT * FROM SiteConfig ORDER BY CreatedAt DESC;
END;