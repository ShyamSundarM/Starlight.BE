CREATE proc [dbo].[updBrand]
@Name nvarchar(200),
@Id int,
@Active bit
As
Begin
update Brands set Name=@Name, Active=@Active where Id = @Id
End