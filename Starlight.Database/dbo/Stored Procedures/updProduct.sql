CREATE proc updProduct  
@Id int,  
@BrandId int = null,  
@Name nvarchar(200) = null,  
@Active bit = null  
As  
Begin  
update Products set   
BrandId=coalesce(@BrandId, BrandId),  
Name = coalesce(@Name, Name),  
Active = coalesce(@Active, Active),  
UpdatedAt = getdate()  
Where
Id=@Id
End