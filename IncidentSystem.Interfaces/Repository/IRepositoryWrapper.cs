using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentSystem.Interfaces.Repository
{
    public interface IRepositoryWrapper
    {
        IIncidentRepository Incident { get; }
    }
}
