using EducationalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalProject.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
