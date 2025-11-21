CREATE PROCEDURE [dbo].[insSiteConfig]
	@ConfigKey NVARCHAR(100),
    @ConfigValue NVARCHAR(MAX),
    @IsActive BIT = 1
AS
BEGIN
    INSERT INTO SiteConfig ([Key], [Value], IsActive)
    VALUES (@ConfigKey, @ConfigValue, @IsActive);
END;