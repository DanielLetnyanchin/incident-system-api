using System;
using System.Diagnostics;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using IncidentSystem.Interfaces;
using IncidentSystem.API.ActionFilters;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IncidentSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IncidentSystem.API.Controllers
{
    [Route("api/incidents")]
    public class IncidentsController : Controller
    {
        private DatabaseContext _dbContext;
        private ILoggerWrapper _logger;

        public IncidentsController(ILoggerWrapper logger, DatabaseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        
        [HttpGet()]
        public async Task<IActionResult> GetIncidents()
        {
            //throw new Exception("Custom exception for testing");
            
            return Ok(await _dbContext.Incidents.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncident(int id)
        {
            //throw new Exception("Custom exception for testing");

            return new JsonResult(await _dbContext.Incidents.Where(i => i.IncidentId == id).ToListAsync());
        }

        [HttpPost()]
        public async Task<IActionResult> AddIncident(Incident incident)
        {
            _dbContext.Incidents.Add(incident);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
