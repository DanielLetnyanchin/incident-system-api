using DataAccess.Entities.Interfaces;
using System;

namespace DataAccess.Entities
{
    public class Incident : IModificationHistory
    {
        public int IncidentId { get; set; }

        public string Description { get; set; }
        public string Status { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
