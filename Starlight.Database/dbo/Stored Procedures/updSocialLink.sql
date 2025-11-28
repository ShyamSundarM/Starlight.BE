CREATE PROCEDURE updSocialLink
    @Name NVARCHAR(MAX) = NULL,
    @Logo NVARCHAR(MAX) = NULL,
    @Url NVARCHAR(MAX) = NULL, 
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE SocialLinks
    SET 
        Name = COALESCE(@Name, Name),
        Logo = COALESCE(@Logo, Logo),
        Url  = COALESCE(@Url, Url)
    WHERE Id = @Id;
END