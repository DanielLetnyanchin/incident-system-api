using IncidentSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using IncidentSystem.Models.Entities;

namespace IncidentSystem.Tests
{
    class TestDatabaseContext : DatabaseContext
    {
        public TestDatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public TestDatabaseContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>().HasData
            (
                new Incident { IncidentId = 1, Description = "Regular 'dividing by zero' incident, nothing special", Status = "Opened" },
                new Incident { IncidentId = 2, Description = "Pug-dog rebellion", Status = "Pending" },
                new Incident { IncidentId = 3, Description = "Grass is green", Status = "Declined" }
            );

            modelBuilder.Entity<UserAccount>().HasData
            (
                new UserAccount { UserAccountId = 1, UserName = "Blue", FirstName = "Caitlin", LastName = "Cleric", Email = "caitlin_cleric@erathia.com", Password = "caitlin_cleric@erathia.com", IsAdmin = true },
                new UserAccount { UserAccountId = 2, UserName = "Red", FirstName = "Sandro", LastName = "Necromancer", Email = "sandro_necromancer@deyja.com", Password = "sandro_necromancer@deyja.com", IsAdmin = false },
                new UserAccount { UserAccountId = 3, UserName = "Green", FirstName = "Pasis", LastName = "Planeswalker", Email = "pasis_planeswalker@conflux.com", Password = "pasis_planeswalker@conflux.com", IsAdmin = false },
                new UserAccount { UserAccountId = 4, UserName = "Purple", FirstName = "Solmyr", LastName = "Wizard", Email = "solmyr_wizard@bracada.com", Password = "solmyr_wizard@bracada.com", IsAdmin = false }
            );
        }
    }
}
