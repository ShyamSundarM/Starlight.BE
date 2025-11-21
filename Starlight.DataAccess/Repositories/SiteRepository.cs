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
                return (await _dbContext.Connection.QueryAsync<SiteConfigItem>("lstSiteConfig", commandType: CommandType.StoredProcedure)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
