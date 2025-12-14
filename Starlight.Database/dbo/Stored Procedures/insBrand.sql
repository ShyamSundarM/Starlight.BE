create proc insBrand
@Name nvarchar(200)
As
Begin
Insert into Brands values(@Name, 1, getdate(), getdate())
select @@IDENTITY
End