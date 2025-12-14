CREATE PROCEDURE RegisterUser
    @Email NVARCHAR(200),
    @Name nvarchar(max),
    @Password NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if email already exists
    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
    BEGIN
        SELECT 2 AS Code; -- Email already exists
        RETURN;
    END

    BEGIN TRY
        INSERT INTO Users (Name, Email, Password)
        VALUES (
            @Name,
            @Email,
            HASHBYTES('SHA2_256', @Password)
        );

        SELECT 1 AS Code; -- Registered successfully
    END TRY
    BEGIN CATCH
        SELECT 0 AS Code; -- Some unknown error
    END CATCH
END