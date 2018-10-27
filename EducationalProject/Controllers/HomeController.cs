using EducationalProject.Models.Interfaces;
using EducationalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EducationalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIncidentRepository _incidentRepository;

        public HomeController(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {


            var incidents = _incidentRepository.GetAllIncidents().OrderBy(i => i.IncidentId);

            var homeViewModel = new HomeViewModel()
            {
                Title = "Educational Project Home Page",
                Incidents = incidents.ToList()
            };

            return View(homeViewModel);
        }
    }
}
