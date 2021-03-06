﻿using IncidentSystem.Models.Entities.Interfaces;
using System;

namespace IncidentSystem.Models.Entities
{
    public class UserAccount : IModificationHistory
    {
        public int UserAccountId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
