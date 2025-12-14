CREATE proc selProductLinks  
@ProductId int  
As  
  
Begin  
  
select pl.Id As ProductLinkId,  
p.Name,  
pl.*
From ProductLinks pl  
Inner join Platforms p on pl.PlatformId = p.Id  
Where ProductId = @ProductId  
  
End