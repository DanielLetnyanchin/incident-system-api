using System.Collections.Generic;

namespace EducationalProject.Models.Interfaces
{
    public interface IIncidentRepository
    {
        IEnumerable<Incident> GetAllIncidents();
        Incident GetIncidentById(int incidentId);

        void AddIncident(Incident incident);
    }
}
