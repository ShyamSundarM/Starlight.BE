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

        public async Task<Dictionary<string, SiteConfigItem>> GetSiteConfigItemsAsync()
        {
            try
            {
                var data = (await _dbContext.Connection.QueryAsync<SiteConfigItem>("lstSiteConfig", commandType: CommandType.StoredProcedure)).ToList();
                var dictionary = new Dictionary<string, SiteConfigItem>();
                foreach (var item in data)
                {
                    dictionary[item.Key] = item;
                }

                return dictionary;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
