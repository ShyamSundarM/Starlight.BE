using Dapper;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;
using System.Data;

namespace Starlight.DataAccess.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private IDbContext _dbContext;
        public SiteRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SiteConfigItem>> GetSiteConfigItemsAsync()
        {
            try
            {
                var data = (await _dbContext.Connection.QueryAsync<SiteConfigItem>("lstSiteConfig", commandType: CommandType.StoredProcedure)).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SiteConfigItem?> GetSiteConfigItemByKeyAsync(string key)
        {
            try
            {
                return await _dbContext.Connection.QueryFirstOrDefaultAsync<SiteConfigItem>("SELECT * FROM SiteConfig WHERE [Key] = @Key", new { Key = key });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> AddSiteConfigItemAsync(SiteConfigItem item)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ConfigKey", item.Key, DbType.String);
                parameters.Add("@ConfigValue", item.Value, DbType.String);
                var sql = "insSiteConfig";
                var id = await _dbContext.Connection.ExecuteScalarAsync<int>(sql, parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateSiteConfigItemAsync(SiteConfigItem item)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", item.Id, DbType.Int32);
                parameters.Add("@ConfigKey", item.Key, DbType.String);
                parameters.Add("@ConfigValue", item.Value, DbType.String);
                parameters.Add("@IsActive", item.IsActive, DbType.Boolean);
                var affected = await _dbContext.Connection.ExecuteAsync("updSiteConfig", parameters, commandType: CommandType.StoredProcedure);
                return affected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteSiteConfigItemAsync(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                var affected = await _dbContext.Connection.ExecuteAsync("delSiteConfig", parameters, commandType: CommandType.StoredProcedure);
                return affected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
