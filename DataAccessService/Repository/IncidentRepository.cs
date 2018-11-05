using Models.Entities;
using System.Collections.Generic;
using System.Linq;
using Contracts.Repository;

namespace DataAccessService.Repository
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly DatabaseContext _appDbContext;

        public IncidentRepository(DatabaseContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddIncident(Incident incident)
        {
            _appDbContext.Incidents.Add(incident);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Incident> GetAllIncidents()
        {
            return _appDbContext.Incidents;
        }

        public Incident GetIncidentById(int incidentId)
        {
            return _appDbContext.Incidents.FirstOrDefault(i => i.IncidentId == incidentId);
        }
    }
}
