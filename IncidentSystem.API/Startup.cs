using System;
using System.IO;
using IncidentSystem.Interfaces;
using IncidentSystem.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using IncidentSystem.Common;
using IncidentSystem.API.ActionFilters;

namespace IncidentSystem.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Moove to extand method all config
            services.AddDbContext<DatabaseContext>(
                options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("WebAPI")));

            services.AddSingleton<ILoggerWrapper, LoggerWrapper>();

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionFilter)); // Registering filter globally
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
