using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope(); //may need to add using Microsoft.Extensions.DependencyInjection;
            var services = scope.ServiceProvider;
            
            //using the service locator pattern.  
            //services for datacontext is located in startup.cs
            //creating the database here, if it's not there.
            //if it is, it updates the database if need be
            try
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();

                //seeding data
                await Seed.SeedData(context);
            } 
            catch (Exception ex) 
            {
               var logger = services.GetRequiredService<ILogger<Program>>();
               logger.LogError(ex, "An error occured during migration");
            }

            await host.RunAsync(); //this starts the application.  dont have it, app never starts
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
