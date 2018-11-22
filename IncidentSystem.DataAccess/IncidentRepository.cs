using IncidentSystem.Models.Entities;
using IncidentSystem.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentSystem.DataAccess
{
    public class IncidentRepository : RepositoryAsync<Incident>, IIncidentRepository
    {
        public IncidentRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
