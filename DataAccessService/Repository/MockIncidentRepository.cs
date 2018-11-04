using Contracts.Repository;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessService.Repository
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
                new Incident{ IncidentId = 1, Description = "Regular 'dividing by zero' incident, nothing special", Status = "Opened" },
                new Incident{ IncidentId = 2, Description = "Pug-dog rebellion", Status = "Pending" },
                new Incident{ IncidentId = 3, Description = "Grass is green", Status = "Declined" }
            };

        }
        public IEnumerable<Incident> GetAllIncidents()
        {
            return _incidents;
        }

        public Incident GetIncidentById(int incidentId)
        {
            return _incidents.FirstOrDefault(a => a.IncidentId == incidentId);
        }

        public void AddIncident(Incident incident)
        {
            _incidents.Add(incident);
        }
    }
}
