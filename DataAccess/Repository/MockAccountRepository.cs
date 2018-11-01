using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class MockAccountRepository : IAccountRepository
    {
        private List<Account> _accounts;

        public MockAccountRepository()
        {
            if (_accounts == null)
            {
                InitializeAccounts();
            }
        }

        private void InitializeAccounts()
        {
            _accounts = new List<Account>
            {
                new Account{ AccountId = 1, FirstName = "Caitlin", LastName = "Cleric", Email = "caitlin_cleric@erathia.com", Password = "caitlin_cleric@erathia.com", IsAdmin = true},
                new Account{ AccountId = 2, FirstName = "Sandro", LastName = "Necromancer", Email = "sandro_necromancer@deyja.com", Password = "sandro_necromancer@deyja.com", IsAdmin = false},
                new Account{ AccountId = 3, FirstName = "Pasis", LastName = "Planeswalker", Email = "pasis_planeswalker@conflux.com", Password = "pasis_planeswalker@conflux.com", IsAdmin = false},
                new Account{ AccountId = 4, FirstName = "Solmyr", LastName = "Wizard", Email = "solmyr_wizard@bracada.com", Password = "solmyr_wizard@bracada.com", IsAdmin = false}
            };

        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }

        public Account GetAccountById(int accountId)
        {
            return _accounts.FirstOrDefault(a => a.AccountId == accountId);
        }
    }
}
