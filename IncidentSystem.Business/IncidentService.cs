using IncidentSystem.DataAccess;
using IncidentSystem.DataAccess.Queries;
using IncidentSystem.Interfaces;
using IncidentSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentSystem.Business
{
    public class IncidentService : IIncidentService
    {
        private DatabaseContext _dbContext;

        public IncidentService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddNewIncidentAsync(Incident incident)
        {
            await _dbContext.Incidents.AddAsync(incident);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Incident>> GetAllIncidentsAsync()
        {
            return await _dbContext.Incidents.ToListAsync();
        }

        public async Task<Incident> GetIncidentByIdAsync(int id)
        {
            return await _dbContext.Incidents.Where(IncidentQueries.IncidentById(id)).SingleAsync();
        }
    }
}