using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NetCoreAPI5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })

                .ConfigureLogging(logBuilder =>
                {
                    logBuilder.ClearProviders(); //Removes all providers from loggerFactory

                    logBuilder.AddConsole();
                    logBuilder.AddDebug();
                    logBuilder.AddEventLog();
                    logBuilder.AddEventSourceLogger();
                    logBuilder.AddTraceSource("Information, ActivityTracing"); //Add Trace Listner provider
                });
    }
}
