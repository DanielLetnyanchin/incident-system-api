﻿using EducationalProject.Models.Interfaces;
using System;

namespace EducationalProject.Models
{
    public class Account : IModificationHistory
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
