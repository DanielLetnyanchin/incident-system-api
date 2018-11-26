using IncidentSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IncidentSystem.Interfaces
{
    public interface IIncidentService
    {
        Task<List<Incident>> GetAllIncidents();
        Task<Incident> GetIncidentById();
        Task AddNewIncidentAsync(Incident incident);
    }
}
