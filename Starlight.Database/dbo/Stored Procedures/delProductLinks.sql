create proc delProductLinks
@ProductId int
As
Begin
delete from ProductLinks where ProductId = @ProductId
End