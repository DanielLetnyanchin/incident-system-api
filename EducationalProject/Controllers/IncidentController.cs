using EducationalProject.Models.Interfaces;
using EducationalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducationalProject.Controllers
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
        public IActionResult Index(Incident incident)
        {
            if (ModelState.IsValid)
            {
                _incidentRepository.AddIncident(incident);
                return RedirectToAction("IncidentAdded");
            }
            return View(incident);
        }

        public IActionResult IncidentAdded()
        {
            return View();
        }
    }
}
