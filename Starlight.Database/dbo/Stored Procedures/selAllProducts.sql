CREATE proc selAllProducts      
As      
begin      
      
select       
p.Id As ProductId,      
b.Id As BrandId,      
b.Name As BrandName,    
p.Name,      
p.Active,  
p.CreatedAt,      
p.UpdatedAt      
from      
Products p       
left join brands b on p.BrandId = b.Id      
Where p.Active = 1 AND b.Active = 1
End