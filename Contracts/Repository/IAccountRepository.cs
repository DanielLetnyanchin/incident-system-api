using Models.Entities;
using System.Collections.Generic;

namespace Contracts.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(int accountId);
    }
}
