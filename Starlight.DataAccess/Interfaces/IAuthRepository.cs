using Starlight.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starlight.DataAccess.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetUserAsync(UserLogin user);
    }
}
