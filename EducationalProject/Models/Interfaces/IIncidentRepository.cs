using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalProject.Models.Interfaces
{
    public interface IIncidentRepository
    {
        IEnumerable<Incident> GetAllIncidents();
        Incident GetIncidentById(int incidentId);
    }
}
