using Models.ViewModels;
using Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Contracts.Repository;

namespace WebAPI.Controllers
{
    public class IncidentController : Controller
    {
        public readonly IIncidentRepository _incidentRepository;

        public IncidentController(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IncidentViewModel incidentViewModel)
        {
            if (ModelState.IsValid)
            {
                _incidentRepository.AddIncident(new Incident { Description = incidentViewModel.Description, Status = incidentViewModel.Status });
                return RedirectToAction("IncidentAdded");
            }
            return View(incidentViewModel);
        }

        public IActionResult IncidentAdded()
        {
            return View();
        }
    }
}
