using System.Linq;

namespace EducationalProject.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
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
