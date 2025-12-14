create proc delBrand
@Id int
As 
Begin
delete from Brands where Id=@Id
End