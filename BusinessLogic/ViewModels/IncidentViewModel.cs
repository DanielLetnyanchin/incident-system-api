using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.ViewModels
{
    public class IncidentViewModel
    {
        [BindNever]
        public int IncidentId { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
    }
}
