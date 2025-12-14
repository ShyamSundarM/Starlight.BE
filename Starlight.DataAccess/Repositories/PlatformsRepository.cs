using Dapper;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;
using System.Data;

namespace Starlight.DataAccess.Repositories
{
    public class PlatformsRepository : IPlatformsRepository
    {
        private readonly IDbContext _dbContext;
        public PlatformsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Platform>> GetPlatformsAsync()
        {
            try
            {
                var data = (await _dbContext.Connection.QueryAsync<Platform>("SelPlatforms", commandType: CommandType.StoredProcedure)).ToList();
                return data;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> InsertPlatform(string name)
        {
            try
            {
                var id = await _dbContext.Connection.QuerySingleAsync<int>("InsPlatforms", new { Name = name }, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdatePlatform(int id, string name)
        {
            try
            {
                var rows = await _dbContext.Connection.QuerySingleAsync<int>("UpdPlatforms", new { Id = id, Name = name }, commandType: CommandType.StoredProcedure);
                return rows;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeletePlatform(int id)
        {
            try
            {
                var rows = await _dbContext.Connection.QuerySingleAsync<int>("DelPlatforms", new { Id = id }, commandType: CommandType.StoredProcedure);
                return rows;
            }
            catch
            {
                throw;
            }
        }
    }
}
