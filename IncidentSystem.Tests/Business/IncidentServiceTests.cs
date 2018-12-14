using IncidentSystem.DataAccess;
using IncidentSystem.DataAccess.Queries;
using IncidentSystem.Interfaces;
using IncidentSystem.Models.Entities;
using IncidentSystem.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        [TestMethod]
        public async Task GetAllIncidentsAsyncShouldReturnAllIncidents()
        {
            optionsBuilder.UseInMemoryDatabase("GetAllIncidentsAsyncShouldReturnAllIncidents");
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                context.AddRange
                (
                    new Incident { Description = "Regular 'dividing by zero' incident, nothing special", Status = "Opened" },
                    new Incident { Description = "Pug-dog rebellion", Status = "Pending" },
                    new Incident { Description = "Grass is green", Status = "Declined" }
                );
                context.SaveChanges();

                IIncidentService testIncidentService = new IncidentService(context);                
                var incidents = await testIncidentService.GetAllIncidentsAsync();
                incidents.ToList();

                Assert.AreEqual(3, incidents.Count());
            }
        }

        [TestMethod]
        public async Task GetAllIncidentsAsyncShouldReturnEmptyIEnumerableIfThereNoIncidents()
        {
            optionsBuilder.UseInMemoryDatabase("GetAllIncidentsAsyncShouldReturnEmptyIEnumerableIfThereNoIncidents");
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                IIncidentService testIncidentService = new IncidentService(context);
                var incidents = await testIncidentService.GetAllIncidentsAsync();

                Assert.IsFalse(incidents.Any());
            }
        }

        [TestMethod]
        public async Task GetIncidentByIdAsyncShouldReturnNullIfThereNoMatchingId()
        {
            int testId = 110;

            optionsBuilder.UseInMemoryDatabase("GetIncidentByIdAsyncShouldReturnNullIfThereNoMatchingId");
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                context.AddRange
                (
                    new Incident { Description = "Regular 'dividing by zero' incident, nothing special", Status = "Opened" },
                    new Incident { Description = "Pug-dog rebellion", Status = "Pending" },
                    new Incident { Description = "Grass is green", Status = "Declined" }
                );

                IIncidentService testIncidentService = new IncidentService(context);
                var incident = await testIncidentService.GetIncidentByIdAsync(testId);

                Assert.AreEqual(null, incident);
            }
        }

        [TestMethod]
        public async Task GetIncidentByIdAsyncShouldReturnIncidentByMatchingId()
        {
            int testId = 3;

            optionsBuilder.UseInMemoryDatabase("GetIncidentByIdAsyncShouldReturnIncidentByMatchingId");
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                context.AddRange
                (
                    new Incident { Description = "Regular 'dividing by zero' incident, nothing special", Status = "Opened" },
                    new Incident { Description = "Pug-dog rebellion", Status = "Pending" },
                    new Incident { Description = "Grass is green", Status = "Declined" }
                );               

                IIncidentService testIncidentService = new IncidentService(context);
                var incident = await testIncidentService.GetIncidentByIdAsync(testId);

                Assert.AreEqual(testId, incident.IncidentId);
            }
        }


        [TestMethod]
        public async Task GetSingleIncidentByExpressionAsyncShouldReturnSingleIncidentByExpressionIncidentById()
        {
            int testId = 3;
            Expression<Func<Incident, bool>> testExpression = IncidentQueries.IncidentById(testId);

            optionsBuilder.UseInMemoryDatabase("GetSingleIncidentByExpressionAsyncShouldReturnSingleIncidentByExpressionIncidentById");
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                context.AddRange
                (
                    new Incident { Description = "Regular 'dividing by zero' incident, nothing special", Status = "Opened" },
                    new Incident { Description = "Pug-dog rebellion", Status = "Pending" },
                    new Incident { Description = "Grass is green", Status = "Declined" }
                );

                IIncidentService testIncidentService = new IncidentService(context);
                var incident = await testIncidentService.GetSingleIncidentByExpressionAsync(testExpression);

                Assert.AreNotEqual(null, incident);
                Assert.AreEqual(testId, incident.IncidentId);
            }
        }

        [TestMethod]
        public async Task GetSingleIncidentByExpressionAsyncShouldReturnNullIfThereNoMatchingIdByExpressionIncidentById()
        {
            int testId = 110;
            Expression<Func<Incident, bool>> testExpression = IncidentQueries.IncidentById(testId);

            optionsBuilder.UseInMemoryDatabase("GetSingleIncidentByExpressionAsyncShouldReturnNullIfThereNoMatchingIdByExpressionIncidentById");
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                context.AddRange
                (
                    new Incident { Description = "Regular 'dividing by zero' incident, nothing special", Status = "Opened" },
                    new Incident { Description = "Pug-dog rebellion", Status = "Pending" },
                    new Incident { Description = "Grass is green", Status = "Declined" }
                );

                IIncidentService testIncidentService = new IncidentService(context);
                var incident = await testIncidentService.GetSingleIncidentByExpressionAsync(testExpression);

                Assert.AreEqual(null, incident);
            }
        }
    }
}
