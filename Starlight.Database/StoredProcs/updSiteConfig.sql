CREATE PROCEDURE [dbo].[updSiteConfig]
	@Id INT,
    @ConfigKey NVARCHAR(100),
    @ConfigValue NVARCHAR(MAX),
    @IsActive BIT
AS
BEGIN
    UPDATE SiteConfig
    SET 
        [Key] = @ConfigKey,
        [Value] = @ConfigValue,
        IsActive = @IsActive,
        UpdatedAt = SYSDATETIME()
    WHERE Id = @Id;
END;
