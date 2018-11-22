using IncidentSystem.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentSystem.DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext;
        private IIncidentRepository _incident;

        public IIncidentRepository Incident
        {
            get
            {
                if (_incident == null)
                {
                    _incident = new IncidentRepository(_dbContext);
                }

                return _incident;
            }
        }

        public RepositoryWrapper(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
