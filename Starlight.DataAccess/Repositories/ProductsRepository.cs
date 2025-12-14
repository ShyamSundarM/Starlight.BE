using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Dapper;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;
using System.Data;
using System.Text.Json;

namespace Starlight.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private IDbContext _dbContext;
        public ProductsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                var data = (await _dbContext.Connection.QueryAsync<Product>("selAllProducts", commandType: CommandType.StoredProcedure)).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ProductLink>> GetProductLinks(int productId)
        {
            try
            {
                var data = (await _dbContext.Connection.QueryAsync<ProductLink>("selProductLinks", new { ProductId = productId }, commandType: CommandType.StoredProcedure)).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertProduct(Product product)
        {
            try
            {
                var id = await _dbContext.Connection.QuerySingleAsync<int>("insProduct", new { BrandId = product.BrandId, Name = product.Name }, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertProductLinks(IEnumerable<ProductLink> links)
        {
            try
            {
                var json = JsonSerializer.Serialize(links.Select(l => new { l.ProductId, l.PlatformId, l.Url }));
                var rows = await _dbContext.Connection.ExecuteAsync("insProductLinks", new { Json = json }, commandType: CommandType.StoredProcedure);
                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProduct(Product product)
        {
            try
            {
                await _dbContext.Connection.ExecuteAsync("updProduct", new { Id = product.ProductId, BrandId = product.BrandId, Name = product.Name, Active = product.Active }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteProductLinks(int productId)
        {
            try
            {
                var rows = await _dbContext.Connection.ExecuteAsync("delProductLinks", new { ProductId = productId }, commandType: CommandType.StoredProcedure);
                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteProductSocialLinks(int productId)
        {
            try
            {
                var rows = await _dbContext.Connection.ExecuteAsync("delProductSocialLinks", new { ProductId = productId }, commandType: CommandType.StoredProcedure);
                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteProduct(int productId)
        {
            try
            {
                var rows = await _dbContext.Connection.ExecuteAsync("delProduct", new { Id = productId }, commandType: CommandType.StoredProcedure);
                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
