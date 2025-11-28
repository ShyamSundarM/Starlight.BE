using Dapper;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starlight.DataAccess.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private IDbContext _dbContext;
        public AuthRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserAsync(UserLogin user)
        {
            try
            {
                return await _dbContext.Connection.QueryFirstOrDefaultAsync<User>("LoginUser", new { user.Email, user.Password }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
