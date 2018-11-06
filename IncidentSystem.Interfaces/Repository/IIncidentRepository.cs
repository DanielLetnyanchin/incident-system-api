using IncidentSystem.Models.Entities;
using System.Collections.Generic;

namespace IncidentSystem.Interfaces
{
    public interface IIncidentRepository
    {
        IEnumerable<Incident> GetAllIncidents();
        Incident GetIncidentById(int incidentId);

        void AddIncident(Incident incident);
    }
}
