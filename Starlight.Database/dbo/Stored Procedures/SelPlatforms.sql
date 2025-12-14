CREATE PROCEDURE SelPlatforms
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name
    FROM Platforms
    ORDER BY Name;
END