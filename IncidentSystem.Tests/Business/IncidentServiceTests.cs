using IncidentSystem.DataAccess;
using IncidentSystem.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IncidentSystem.Business.Tests
{
    [TestClass]
    public class IncidentServiceTests
    {
        private DbContextOptionsBuilder<DatabaseContext> optionsBuilder
            = new DbContextOptionsBuilder<DatabaseContext>();

        [TestMethod]
        public void HasNoSeedData()
        {
            optionsBuilder.UseInMemoryDatabase("HasNoSeedData");
            using (var context = new TestDatabaseContext(optionsBuilder.Options))
            {
                var incidents = context.Incidents.ToList();
                Assert.AreEqual(0, incidents.Count());
            }
        }

        [TestMethod]
        public void HasSeedData()
        {
            optionsBuilder.UseInMemoryDatabase("HasSeedData");
            using (var context = new TestDatabaseContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
                Assert.AreNotEqual(0, context.Incidents.Count());
            }
        }
    }
}
