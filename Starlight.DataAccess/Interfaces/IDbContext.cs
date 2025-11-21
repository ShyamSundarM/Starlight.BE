
using System.Data;

namespace Starlight.DataAccess.Interfaces
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
