using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using STEINBAUERPizzeria.Data;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace STEINBAUERPizzeria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

            try
            {
                Log.Information("Starting up");
                // Get the IWebHost which will host this application.
                var host = CreateHostBuilder(args).Build();

                // Find the service layer within our scope.
                using (var scope = host.Services.CreateScope())
                {
                    // Get the instance of DataContext in our services layer
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<DataContext>();

                    // Call PizzaSeedData to create sample data
                    PizzaSeedData.Initialize(services);
                }

                // Continue to run the application
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            

            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
