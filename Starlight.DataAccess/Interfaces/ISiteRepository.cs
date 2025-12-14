using Starlight.DataAccess.Models;

namespace Starlight.DataAccess.Interfaces
{
    public interface ISiteRepository
    {
        public Task<List<SiteConfigItem>> GetSiteConfigItemsAsync();
        public Task<SiteConfigItem?> GetSiteConfigItemByKeyAsync(string key);
        public Task<int> AddSiteConfigItemAsync(SiteConfigItem item);
        public Task<bool> UpdateSiteConfigItemAsync(SiteConfigItem item);
        public Task<bool> DeleteSiteConfigItemAsync(int id);
    }
}
