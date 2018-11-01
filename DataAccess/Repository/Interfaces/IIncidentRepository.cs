using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Repository.Interfaces
{
    public interface IIncidentRepository
    {
        IEnumerable<Incident> GetAllIncidents();
        Incident GetIncidentById(int incidentId);

        void AddIncident(Incident incident);
    }
}
