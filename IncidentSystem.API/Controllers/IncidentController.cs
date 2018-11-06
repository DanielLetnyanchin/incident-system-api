using System;
using System.Diagnostics;
using IncidentSystem.Models.ViewModels;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using IncidentSystem.Interfaces;

namespace IncidentSystem.API.Controllers
{
    public class IncidentController : Controller
    {
        public readonly IIncidentRepository _incidentRepository;
        private ILoggerWrapper _logger;

        public IncidentController(IIncidentRepository incidentRepository, ILoggerWrapper logger)
        {
            _incidentRepository = incidentRepository;
            _logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IncidentViewModel incidentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _incidentRepository.AddIncident(new Incident { Description = incidentViewModel.Description, Status = incidentViewModel.Status });
                    return RedirectToAction("IncidentAdded");
                }
            }
            catch (Exception e)
            {
                _logger.Info(e.Message, e.StackTrace);
            }

            return View(incidentViewModel);
        }

        public IActionResult IncidentAdded()
        {
            return View();
        }
    }
}
