using IncidentSystem.DataAccess;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IncidentSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DB Seeder
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DatabaseContext>();
                    DatabaseInitializer.InitializeIncidents(context);
                    DatabaseInitializer.InitializeUserAccounts(context);
                }
                catch (Exception ex)
                {
                    throw ex;
                    //we could log this in a real-world situation
                }
            }
            host.Run();

            //CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>();

        private static void SetupConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            // Removing default configuration options
            builder.Sources.Clear();

            builder.AddJsonFile("AppConfig.json", false, true)
                    .AddEnvironmentVariables();
        }
    }
}
