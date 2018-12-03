using IncidentSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IncidentSystem.Interfaces
{
    public interface IIncidentService
    {
        Task<IEnumerable<Incident>> GetAllIncidentsAsync();
        Task<Incident> GetIncidentByIdAsync(int id);
        Task AddNewIncidentAsync(Incident incident);
        Task<IEnumerable<Incident>> GetIncidentCollectionByExpressionAsync(Expression<Func<Incident, bool>> expression);
        Task<Incident> GetSingleIncidentByExpressionAsync(Expression<Func<Incident, bool>> expression);
    }
}
