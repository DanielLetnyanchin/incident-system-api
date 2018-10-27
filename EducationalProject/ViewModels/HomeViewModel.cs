using EducationalProject.Models;
using System.Collections.Generic;

namespace EducationalProject.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
