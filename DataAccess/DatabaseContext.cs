using DataAccess.Entities;
using DataAccess.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            foreach(var history in ChangeTracker.Entries()
                                                .Where(e => e.Entity is IModificationHistory &&
                                                (e.State == EntityState.Added || e.State == EntityState.Modified))
                                                .Select(e => e.Entity as IModificationHistory))
            {
                history.DateModified = DateTime.Now;
                if(history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
