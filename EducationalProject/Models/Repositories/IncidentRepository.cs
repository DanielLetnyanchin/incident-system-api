using EducationalProject.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalProject.Models.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly AppDbContext _appDbContext;

        public IncidentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Incident> GetAllIncidents()
        {
            return _appDbContext.Incidents;
        }

        public Incident GetIncidentById(int incidentId)
        {
            return _appDbContext.Incidents.FirstOrDefault(i => i.Id == incidentId);
        }
    }
}
