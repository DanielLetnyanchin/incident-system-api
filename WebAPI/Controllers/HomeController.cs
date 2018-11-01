using BusinessLogic.Mapper;
using BusinessLogic.ViewModels;
using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
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


            var incidents = new List<Incident>(_incidentRepository.GetAllIncidents().OrderBy(i => i.IncidentId));

            var homeViewModel = new HomeViewModel()
            {
                Title = "Educational Project Home Page",
                Incidents = MockMapper.MapToIncidentViewModels(incidents)
            };

            return View(homeViewModel);
        }
    }
}
