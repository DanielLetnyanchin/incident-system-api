﻿using System;
using System.Diagnostics;
using IncidentSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using IncidentSystem.Interfaces;
using IncidentSystem.API.ActionFilters;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IncidentSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using IncidentSystem.DataAccess.Queries;

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
        public async Task<IActionResult> GetIncident(int id)
        {
            //throw new Exception("Custom exception for testing");

            return new JsonResult(await _incidentService.GetIncidentByIdAsync(id));
        }

        [HttpPost()]
        public async Task<IActionResult> AddIncident(Incident incident)
        {
            await _incidentService.AddNewIncidentAsync(incident);
            return Ok();
        }
    }
}
