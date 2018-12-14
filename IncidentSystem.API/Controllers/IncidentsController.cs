using IncidentSystem.API.ActionFilters;
using IncidentSystem.DataAccess.Queries;
using IncidentSystem.Interfaces;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Transactions;

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
            Incident resultIncident;
            using (TransactionScope scope = new TransactionScope())
            {
                resultIncident =
                   await _incidentService.GetSingleIncidentByExpressionAsync(IncidentQueries.IncidentById(id));

                scope.Complete();
            }

            return new JsonResult(resultIncident);

        }

        [HttpPost()]
        [TypeFilter(typeof (TransactionScopeFilter))]
        public async Task<IActionResult> AddIncident(Incident incident)
        {
            var testIncident = new Incident { Description = "Pochemu1006?", Status = "TEST1006" };


            await _incidentService.CreateIncidentAsync(testIncident);
            return Ok();
        }
    }
}
