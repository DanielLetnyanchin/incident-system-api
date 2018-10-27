using EducationalProject.Models.Enums;
using EducationalProject.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalProject.Models
{
    public class Incident : IModificationHistory
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public IncidentStatus Status { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
