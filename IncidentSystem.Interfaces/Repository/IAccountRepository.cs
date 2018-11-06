using IncidentSystem.Models.Entities;
using System.Collections.Generic;

namespace IncidentSystem.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(int accountId);
    }
}
