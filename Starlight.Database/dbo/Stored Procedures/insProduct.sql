create proc insProduct
@BrandId int,
@Name nvarchar(200)
As
Begin

insert into Products values(@BrandId, @Name, 1, getdate(), getdate())
select @@IDENTITY
End