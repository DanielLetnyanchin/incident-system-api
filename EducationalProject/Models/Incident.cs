using EducationalProject.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationalProject.Models
{
    public class Incident : IModificationHistory
    {
        [BindNever]
        public int IncidentId { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [BindNever]
        public DateTime DateModified { get; set; }
        [BindNever]
        public DateTime DateCreated { get; set; }
    }
}
