using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Starlight.DataAccess.Interfaces;
using System.Data;

namespace Starlight.DataAccess
{
    public class DBContext : IDbContext
    {
        public IDbConnection Connection { get; }

        public DBContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found.");
            Connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();

            Connection.Dispose();
        }
    }
}
