using IncidentSystem.Models.Entities;
using System.Linq;

namespace IncidentSystem.DataAccess
{
    public static class DatabaseInitializer
    {
        public static void InitializeIncidents(DatabaseContext context)
        {
            if(!context.Incidents.Any())
            {
                context.AddRange
                (
                    new Incident { IncidentId = 1, Description = "Regular 'dividing by zero' incident, nothing special", Status = "Opened" },
                    new Incident { IncidentId = 2, Description = "Pug-dog rebellion", Status = "Pending" },
                    new Incident { IncidentId = 3, Description = "Grass is green", Status = "Declined" }
                );

                context.SaveChanges();
            }
        }

        public static void InitializeAccounts(DatabaseContext context)
        {
            if (!context.Accounts.Any())
            {
                context.AddRange
                (
                    new Account { AccountId = 1, FirstName = "Caitlin", LastName = "Cleric", Email = "caitlin_cleric@erathia.com", Password = "caitlin_cleric@erathia.com", IsAdmin = true },
                    new Account { AccountId = 2, FirstName = "Sandro", LastName = "Necromancer", Email = "sandro_necromancer@deyja.com", Password = "sandro_necromancer@deyja.com", IsAdmin = false },
                    new Account { AccountId = 3, FirstName = "Pasis", LastName = "Planeswalker", Email = "pasis_planeswalker@conflux.com", Password = "pasis_planeswalker@conflux.com", IsAdmin = false },
                    new Account { AccountId = 4, FirstName = "Solmyr", LastName = "Wizard", Email = "solmyr_wizard@bracada.com", Password = "solmyr_wizard@bracada.com", IsAdmin = false }
                );

                context.SaveChanges();
            }
        }
    }
}
