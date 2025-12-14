CREATE PROCEDURE SelPlatforms  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    SELECT Id, Name  
    FROM Platforms  
    Where Id <> 1
    ORDER BY Name
END