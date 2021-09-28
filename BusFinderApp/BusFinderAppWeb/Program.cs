using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusFinderAppWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var logsDatabaseConnectionString = "Server=(localdb)\\MSSqlLocalDb;Integrated Security=true;Database=LogiDB";

            var loggerConfiguration = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("C:\\BusFinder-logs.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                .WriteTo.MSSqlServer(logsDatabaseConnectionString, new MSSqlServerSinkOptions {AutoCreateSqlTable = true, TableName = "BusLogs" })
                .CreateLogger();

            return Host.CreateDefaultBuilder(args)
                .UseSerilog(loggerConfiguration)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }
        
    
}
