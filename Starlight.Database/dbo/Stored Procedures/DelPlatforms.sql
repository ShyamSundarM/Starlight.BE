CREATE PROCEDURE DelPlatforms
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Platforms
    WHERE Id = @Id;

    SELECT @@ROWCOUNT AS RowsAffected;
END