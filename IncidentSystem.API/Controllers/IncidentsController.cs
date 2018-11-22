using System;
using System.Diagnostics;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using IncidentSystem.Interfaces;
using IncidentSystem.API.ActionFilters;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IncidentSystem.API.Controllers
{
    [Route("api/incidents")]
    public class IncidentsController : Controller
    {
        public readonly IRepositoryAsync<Incident> _incidentRepository;
        private ILoggerWrapper _logger;

        public IncidentsController(IRepositoryAsync<Incident> incidentRepository, ILoggerWrapper logger)
        {
            _incidentRepository = incidentRepository;
            _logger = logger;
        }
        
        [HttpGet()]
        public async Task<IActionResult> GetIncidents()
        {
            //throw new Exception("Custom exception for testing");
            
            return Ok(await _incidentRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncident(int id)
        {
            //throw new Exception("Custom exception for testing");

            return new JsonResult(await _incidentRepository.GetByConditionAsync(i => i.IncidentId == id));
        }

        [HttpPost()]
        public async Task<IActionResult> AddIncident(Incident incident)
        {
            _incidentRepository.Add(incident);
            await _incidentRepository.SaveAsync();
            return Ok();
        }
    }
}
