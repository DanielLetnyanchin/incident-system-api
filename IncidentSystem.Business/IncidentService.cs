using IncidentSystem.DataAccess;
using IncidentSystem.Interfaces;
using IncidentSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IncidentSystem.Business
{
    public class IncidentService : IIncidentService
    {
        private DatabaseContext _dbContext;
        private ILoggerWrapper _logger;

        public IncidentService(ILoggerWrapper logger, DatabaseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task AddNewIncidentAsync(Incident incident)
        {
            throw new NotImplementedException();
        }

        public Task<List<Incident>> GetAllIncidents()
        {
            throw new NotImplementedException();
        }

        public Task<Incident> GetIncidentById()
        {
            throw new NotImplementedException();
        }
    }
}