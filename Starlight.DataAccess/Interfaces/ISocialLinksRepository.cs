using Starlight.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starlight.DataAccess.Interfaces
{
    public interface ISocialLinksRepository
    {
        Task<List<SocialLink>> GetSocialLinksAsync();
        Task<int> AddSocialLinkAsync(SocialLink link);
        Task<bool> UpdateSocialLinkAsync(SocialLink link);
        Task<bool> DeleteSocialLinkAsync(int id);
    }
}
