using Starlight.DataAccess.Models;

namespace Starlight.DataAccess.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<ProductLink>> GetProductLinks(int productId);
        Task<int> InsertProduct(Product product);
        Task<int> InsertProductLinks(IEnumerable<ProductLink> links);
        Task UpdateProduct(Product product);
        Task<int> DeleteProductLinks(int productId);
        Task<int> DeleteProduct(int productId);
    }
}
