using IncidentSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentSystem.Interfaces.Repository
{
    public interface IIncidentRepository : IRepositoryAsync<Incident>
    {
    }
}
