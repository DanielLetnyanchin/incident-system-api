using System;
using System.Diagnostics;
using IncidentSystem.Models.ViewModels;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using IncidentSystem.Interfaces;
using IncidentSystem.API.ActionFilters;

namespace IncidentSystem.API.Controllers
{
    public class IncidentController : Controller
    {
        public readonly IRepository<Incident> _incidentRepository;
        private ILoggerWrapper _logger;

        public IncidentController(IRepository<Incident> incidentRepository, ILoggerWrapper logger)
        {
            _incidentRepository = incidentRepository;
            _logger = logger;
        }

        [ServiceFilter(typeof(ControllerFilter))]
        [HttpGet]
        public IActionResult Index()
        {
            throw new Exception("Exception while fetching all the students from the storage.");
            return View();
        }

        [ServiceFilter(typeof(ControllerFilter))]
        [HttpPost]
        public IActionResult Index(IncidentViewModel incidentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _incidentRepository.Add(new Incident { Description = incidentViewModel.Description, Status = incidentViewModel.Status });
                    return View(incidentViewModel);
                }
            }
            catch (Exception e)
            {
                _logger.Info(e.Message, e.StackTrace);
            }

            return View(incidentViewModel);
        }
    }
}
