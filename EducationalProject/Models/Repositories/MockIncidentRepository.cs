using EducationalProject.Models.Enums;
using EducationalProject.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalProject.Models.Repositories
{
    public class MockIncidentRepository: IIncidentRepository
    {
        private List<Incident>_incidents;

        public MockIncidentRepository()
        {
            if (_incidents == null)
            {
                InitializeIncidents();
            }
        }

        private void InitializeIncidents()
        {
            _incidents = new List<Incident>
            {
                new Incident{ Id = 1, Description = "Regular 'dividing by zero' incident, nothing special", Status = IncidentStatus.Opened },
                new Incident{ Id = 2, Description = "Pug-dog rebellion", Status = IncidentStatus.Pending },
                new Incident{ Id = 3, Description = "Grass is green", Status = IncidentStatus.Declined }
            };

        }
        public IEnumerable<Incident> GetAllIncidents()
        {
            return _incidents;
        }

        public Incident GetIncidentById(int incidentId)
        {
            return _incidents.FirstOrDefault(a => a.Id == incidentId);
        }
    }
}
