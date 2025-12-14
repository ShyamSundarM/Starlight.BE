CREATE PROCEDURE LoginUser  
    @Email NVARCHAR(200),  
    @Password NVARCHAR(MAX)  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    DECLARE @StoredHash VARBINARY(64),  
            @ComputedHash VARBINARY(64);  
  
    -- Get the stored password hash  
    SELECT @StoredHash = Password  
    FROM Users  
    WHERE Email = @Email;  
  
    -- If no such user  
    IF (@StoredHash IS NULL)  
    BEGIN  
        RETURN; -- return nothing  
    END  
  
    -- Hash the incoming password  
    SET @ComputedHash = HASHBYTES('SHA2_256', @Password);  
  
    -- If passwords match → return the user record (exclude password!)  
    IF (@ComputedHash = @StoredHash)  
    BEGIN  
        SELECT 
            *
        FROM Users
        WHERE Email = @Email;

        RETURN;
    END  
  
    -- Password mismatch → return nothing  
    RETURN;  
END