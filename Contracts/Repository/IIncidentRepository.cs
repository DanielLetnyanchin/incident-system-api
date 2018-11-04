using Models.Entities;
using System.Collections.Generic;

namespace Contracts.Repository
{
    public interface IIncidentRepository
    {
        IEnumerable<Incident> GetAllIncidents();
        Incident GetIncidentById(int incidentId);

        void AddIncident(Incident incident);
    }
}
