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
        
        [HttpGet]
        public IActionResult Index()
        {
            //throw new Exception("Custom exception for testing");
            
            return View();
        }

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
