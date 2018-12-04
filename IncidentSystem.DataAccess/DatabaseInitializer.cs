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
                    new Incident { Description = "Regular 'dividing by zero' incident, nothing special", Status = "Opened" },
                    new Incident { Description = "Pug-dog rebellion", Status = "Pending" },
                    new Incident { Description = "Grass is green", Status = "Declined" }
                );

                context.SaveChanges();
            }
        }

        public static void InitializeAccounts(DatabaseContext context)
        {
            if (!context.UserAccounts.Any())
            {
                context.AddRange
                (
                    //new UserAccount { FirstName = "Caitlin", LastName = "Cleric", Email = "caitlin_cleric@erathia.com", Password = "caitlin_cleric@erathia.com", IsAdmin = true },
                    //new UserAccount { FirstName = "Sandro", LastName = "Necromancer", Email = "sandro_necromancer@deyja.com", Password = "sandro_necromancer@deyja.com", IsAdmin = false },
                    //new UserAccount { FirstName = "Pasis", LastName = "Planeswalker", Email = "pasis_planeswalker@conflux.com", Password = "pasis_planeswalker@conflux.com", IsAdmin = false },
                    //new UserAccount { FirstName = "Solmyr", LastName = "Wizard", Email = "solmyr_wizard@bracada.com", Password = "solmyr_wizard@bracada.com", IsAdmin = false }
                );

                context.SaveChanges();
            }
        }
    }
}
