create proc delProductSocialLinks  
@ProductId int  
As  
Begin  
delete from ProductLinks where ProductId = @ProductId AND PlatformId <> 1
End