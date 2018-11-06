﻿using IncidentSystem.Models.Entities;
using IncidentSystem.Models.ViewModels;
using System.Collections.Generic;

namespace IncidentSystem.Models.Mapper
{
    public class MockMapper
    {
        public static List<IncidentViewModel> MapToIncidentViewModels(List<Incident> incidents)
        {
            List<IncidentViewModel> results = new List<IncidentViewModel>();

            foreach (Incident incident in incidents)
            {
                results.Add(new IncidentViewModel { IncidentId = incident.IncidentId, Description = incident.Description, Status = incident.Status});
            }
            return results;
        }

        public static Incident MapToIncident(IncidentViewModel incidentViewModel)
        {
            return new Incident { IncidentId = incidentViewModel.IncidentId, Description = incidentViewModel.Description, Status = incidentViewModel.Status };
        }
    }
}