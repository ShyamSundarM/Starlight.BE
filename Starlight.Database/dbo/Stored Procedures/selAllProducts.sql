CREATE proc selAllProducts
As
begin

select 
p.Id As ProductId,
b.Id As BrandId,
p.Name,
p.CreatedAt,
p.UpdatedAt
from
Products p 
left join brands b on p.Id = b.Id

End