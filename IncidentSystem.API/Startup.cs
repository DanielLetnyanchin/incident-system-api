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
using IncidentSystem.Business;
using Microsoft.AspNetCore.Identity;
using IncidentSystem.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IncidentSystem.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Moove to extand method all config
            services.AddDbContext<DatabaseContext>(
                options => options
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("IncidentSystem.API")));

            services.AddSingleton<ILoggerWrapper, LoggerWrapper>();
            services.AddScoped<IIncidentService, IncidentService>();

            services.AddIdentityCore<UserAccount>(options => { });
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _configuration["Tokens:Issuer"],
                        ValidAudience = _configuration["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]))
                    };
                });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionFilter)); // Registering filter globally
            });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
