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
    public class SocialLinksRepository : ISocialLinksRepository
    {
        private IDbContext _dbContext;
        public SocialLinksRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SocialLink>> GetSocialLinksAsync()
        {
            try
            {
                var data = (await _dbContext.Connection.QueryAsync<SocialLink>("lstSocialLinks", commandType: CommandType.StoredProcedure)).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> AddSocialLinkAsync(SocialLink link)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", link.Name, DbType.String);
                parameters.Add("@Logo", link.Logo, DbType.String);
                parameters.Add("@Url", link.Url, DbType.String);
                // assuming stored procedure returns new Id as scalar
                var id = await _dbContext.Connection.ExecuteScalarAsync<int>("insSocialLink", parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateSocialLinkAsync(SocialLink link)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", link.Id, DbType.Int32);
                if(link.Name is not null)
                {
                    parameters.Add("@Name", link.Name, DbType.String);
                }
                if(link.Logo is not null)
                {
                    parameters.Add("@Logo", link.Logo, DbType.String);
                }
                if(link.Url is not null)
                {
                    parameters.Add("@Url", link.Url, DbType.String);
                }
                var affected = await _dbContext.Connection.ExecuteAsync("updSocialLink", parameters, commandType: CommandType.StoredProcedure);
                return affected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteSocialLinkAsync(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                var affected = await _dbContext.Connection.ExecuteAsync("delSocialLink", parameters, commandType: CommandType.StoredProcedure);
                return affected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
