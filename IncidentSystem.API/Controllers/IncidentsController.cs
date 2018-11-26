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
using IncidentSystem.DataAccess.Queries;

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

            return new JsonResult(await _dbContext.Incidents.Where(IncidentQueries.IncidentById(id)).SingleAsync());
        }

        [HttpPost()]
        public async Task<IActionResult> AddIncident(Incident incident)
        {
            return Ok();
        }
    }
}
