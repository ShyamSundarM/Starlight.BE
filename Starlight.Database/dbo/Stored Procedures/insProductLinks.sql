CREATE PROCEDURE insProductLinks
    @Json NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ProductLinks (ProductId, PlatformId, Url)
    SELECT 
        JSON_VALUE(value, '$.ProductId')  AS ProductId,
        JSON_VALUE(value, '$.PlatformId') AS PlatformId,
        JSON_VALUE(value, '$.Url')        AS Url
    FROM OPENJSON(@Json);
END