using IncidentSystem.DataAccess.Queries;
using IncidentSystem.Interfaces;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IncidentSystem.API.Controllers
{
    [Route("api/incidents")]
    public class IncidentsController : Controller
    {
        private IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }
        
        [HttpGet()]
        public async Task<IActionResult> GetIncidents()
        {
            //throw new Exception("Custom exception for testing");

            return Ok(await _incidentService.GetAllIncidentsAsync());
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetIncident(int id)
        {
            //throw new Exception("Custom exception for testing");

            //return new JsonResult(await _incidentService.GetIncidentByIdAsync(id));
            return new JsonResult(await _incidentService.GetSingleIncidentByExpressionAsync(IncidentQueries.IncidentById(id)));
        }

        [HttpPost()]
        public async Task<IActionResult> AddIncident(Incident incident)
        {
            await _incidentService.CreateIncidentAsync(incident);
            return Ok();
        }
    }
}
