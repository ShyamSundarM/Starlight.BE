using Starlight.DataAccess.Models;

namespace Starlight.DataAccess.Interfaces
{
    public interface IBrandsRepository
    {
        Task<int> InsertBrand(string name);
        Task<List<Brand>> GetBrandsAsync();
        Task<int> UpdateBrand(int id, string name, bool active);
        Task<int> DeleteBrand(int id);
    }
}
