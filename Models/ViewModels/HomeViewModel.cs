using System.Collections.Generic;

namespace Models.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<IncidentViewModel> Incidents { get; set; }
    }
}
