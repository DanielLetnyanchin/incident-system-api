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
        Task<UserAccount> GetByIdAsync(int userId);
        Task<UserAccount> GetByUserNameAsync(string userName);
        Task UpdateAsync(UserAccount user);
    }
}