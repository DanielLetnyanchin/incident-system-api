using System;
using System.Diagnostics;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using IncidentSystem.Interfaces;
using IncidentSystem.Interfaces.Repository;
using IncidentSystem.API.ActionFilters;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IncidentSystem.API.Controllers
{
    [Route("api/incidents")]
    public class IncidentsController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        private ILoggerWrapper _logger;

        public IncidentsController(IRepositoryWrapper repoWrapper, ILoggerWrapper logger)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
        }
        
        [HttpGet()]
        public async Task<IActionResult> GetIncidents()
        {
            //throw new Exception("Custom exception for testing");
            
            return Ok(await _repoWrapper.Incident.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncident(int id)
        {
            //throw new Exception("Custom exception for testing");

            return new JsonResult(await _repoWrapper.Incident.GetByConditionAsync(i => i.IncidentId == id));
        }

        [HttpPost()]
        public async Task<IActionResult> AddIncident(Incident incident)
        {
            _repoWrapper.Incident.Add(incident);
            await _repoWrapper.Incident.SaveAsync();
            return Ok();
        }
    }
}
