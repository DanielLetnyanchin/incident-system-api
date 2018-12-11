using IncidentSystem.DataAccess;
using IncidentSystem.DataAccess.Queries;
using IncidentSystem.Interfaces;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IncidentSystem.Business
{
    public class UserAccountService : IUserAccountService
    {
        private DatabaseContext _dbContext;

        public UserAccountService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(UserAccount user)
        {
            _dbContext.UserAccounts.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserAccount user)
        {
            _dbContext.UserAccounts.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
        }

        public async Task<UserAccount> GetByIdAsync(int userId)
        {
            return await _dbContext.UserAccounts.Where(UserAccountQueries.UserAccountById(userId)).SingleOrDefaultAsync();
        }

        public async Task<UserAccount> GetByUserNameAsync(string userName)
        {
            return await _dbContext.UserAccounts.Where(UserAccountQueries.UserAccountByUserName(userName)).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(UserAccount user)
        {
            _dbContext.UserAccounts.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
