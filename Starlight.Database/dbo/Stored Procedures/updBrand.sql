create proc updBrand
@Name nvarchar(200),
@Id int
As
Begin
update Brands set Name=@Name where Id = @Id
End