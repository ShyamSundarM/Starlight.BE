create proc delProduct
@Id int
As
delete from Products where Id = @Id