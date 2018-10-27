using System.Collections.Generic;

namespace EducationalProject.Models.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(int accountId);
    }
}
