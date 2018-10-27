using EducationalProject.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EducationalProject.Models.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly AppDbContext _appDbContext;

        public IncidentRepository(AppDbContext appDbContext)
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
