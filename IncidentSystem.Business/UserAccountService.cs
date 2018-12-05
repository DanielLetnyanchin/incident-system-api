using IncidentSystem.DataAccess;
using IncidentSystem.DataAccess.Queries;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IncidentSystem.Business
{
    public class UserAccountService : IUserStore<UserAccount>, IUserPasswordStore<UserAccount>
    {
        private DatabaseContext _dbContext;

        public UserAccountService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IdentityResult> CreateAsync(UserAccount user, CancellationToken cancellationToken)
        {
            _dbContext.UserAccounts.Add(user);
            await _dbContext.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(UserAccount user, CancellationToken cancellationToken)
        {
            _dbContext.UserAccounts.Remove(user);
            await _dbContext.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public void Dispose()
        {
        }

        public async Task<UserAccount> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await _dbContext.UserAccounts.Where(UserAccountQueries.UserAccountById(userId)).SingleOrDefaultAsync();
        }

        public async Task<UserAccount> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await _dbContext.UserAccounts.Where(UserAccountQueries.UserAccountByNormalizedUserName(normalizedUserName)).SingleOrDefaultAsync();
        }

        public Task<string> GetNormalizedUserNameAsync(UserAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetPasswordHashAsync(UserAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetUserIdAsync(UserAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserAccountId);
        }

        public Task<string> GetUserNameAsync(UserAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<bool> HasPasswordAsync(UserAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(UserAccount user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(UserAccount user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(UserAccount user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(UserAccount user, CancellationToken cancellationToken)
        {
            _dbContext.UserAccounts.Update(user);
            await _dbContext.SaveChangesAsync();
            return IdentityResult.Success;
        }
    }
}
