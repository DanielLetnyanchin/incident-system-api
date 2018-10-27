using EducationalProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    new Incident { Description = "Regular 'dividing by zero' incident, nothing special", Status = IncidentStatus.Opened },
                    new Incident { Description = "Pug-dog rebellion", Status = IncidentStatus.Pending },
                    new Incident { Description = "Grass is green", Status = IncidentStatus.Declined }
                );

                context.SaveChanges();
            }
        }
    }
}
