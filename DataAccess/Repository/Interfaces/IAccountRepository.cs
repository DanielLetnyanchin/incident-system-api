using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Repository.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(int accountId);
    }
}
