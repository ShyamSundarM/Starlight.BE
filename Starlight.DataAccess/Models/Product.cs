namespace Starlight.DataAccess.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string? BrandName { get; set; }

        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<ProductLink> Links { get; set; } = new();
    }
}
