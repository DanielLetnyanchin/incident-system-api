using IncidentSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IncidentSystem.DataAccess.Queries
{
    public static class IncidentQueries
    {
        public static Expression<Func<Incident, bool>> IncidentById(int id)
        {
            return (i => i.IncidentId == id);
        }
    }
}
