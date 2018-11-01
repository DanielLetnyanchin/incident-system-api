using DataAccess.Entities;
using System.Linq;

namespace DataAccess
{
    public static class DatabaseInitializer
    {
        public static void Seed(DatabaseContext context)
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
    }
}
