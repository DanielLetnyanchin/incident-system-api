using System;
using System.Diagnostics;
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
            
            return Ok(_incidentRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Index(Incident incident)
        {
            _incidentRepository.Add(incident);
            _incidentRepository.Save();
            return Ok();
        }
    }
}
