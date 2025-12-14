CREATE PROCEDURE UpdPlatforms
    @Id INT,
    @Name NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Platforms
    SET Name = @Name
    WHERE Id = @Id;

    SELECT @@ROWCOUNT AS RowsAffected;
END