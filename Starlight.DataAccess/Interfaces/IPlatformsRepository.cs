using Starlight.DataAccess.Models;

namespace Starlight.DataAccess.Interfaces
{
    public interface IPlatformsRepository
    {
        Task<List<Platform>> GetPlatformsAsync();
        Task<int> InsertPlatform(string name);
        Task<int> UpdatePlatform(int id, string name);
        Task<int> DeletePlatform(int id);
    }
}
