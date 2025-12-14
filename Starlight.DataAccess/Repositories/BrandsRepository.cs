using Dapper;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;
using System.Data;

namespace Starlight.DataAccess.Repositories
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly IDbContext _dbContext;
        public BrandsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> InsertBrand(string name)
        {
            try
            {
                var id = await _dbContext.Connection.QuerySingleAsync<int>("insBrand", new { Name = name }, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Brand>> GetBrandsAsync()
        {
            try
            {
                var data = (await _dbContext.Connection.QueryAsync<Brand>("selBrands", commandType: CommandType.StoredProcedure)).ToList();
                return data;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateBrand(int id, string name, bool active)
        {
            try
            {
                var rows = await _dbContext.Connection.ExecuteAsync("updBrand", new { Id = id, Name = name, Active = active }, commandType: CommandType.StoredProcedure);
                return rows;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteBrand(int id)
        {
            try
            {
                var rows = await _dbContext.Connection.ExecuteAsync("delBrand", new { Id = id }, commandType: CommandType.StoredProcedure);
                return rows;
            }
            catch
            {
                throw;
            }
        }
    }
}
