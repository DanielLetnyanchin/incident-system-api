using System.Threading;
using System.Threading.Tasks;
using IncidentSystem.Models.Entities;

namespace IncidentSystem.Interfaces
{
    public interface IUserAccountService
    {
        Task CreateAsync(UserAccount user);
        Task DeleteAsync(UserAccount user);
        void Dispose();
        Task<UserAccount> FindByIdAsync(int userId);
        Task<UserAccount> FindByUserNameAsync(string userName);
        Task<string> GetPasswordAsync(UserAccount user);
        Task<int> GetUserIdAsync(UserAccount user);
        Task<string> GetUserNameAsync(UserAccount user);
        Task SetPasswordAsync(UserAccount user, string password);
        Task SetUserNameAsync(UserAccount user, string userName);
        Task UpdateAsync(UserAccount user);
    }
}