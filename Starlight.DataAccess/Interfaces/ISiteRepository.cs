using Starlight.DataAccess.Models;

namespace Starlight.DataAccess.Interfaces
{
    public interface ISiteRepository
    {
        public Task<List<SiteConfigItem>> GetSiteConfigItemsAsync();
    }
}
