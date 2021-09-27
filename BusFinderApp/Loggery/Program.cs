using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loggery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ///////////////////////////////////////////////
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDb; Integrated Security=True; Initial Catalog=Logi";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("C:\\logs.txt")
                .WriteTo.MSSqlServer(connectionString, new MSSqlServerSinkOptions {AutoCreateSqlTable=true, TableName="Logs" })
                .CreateLogger();
            ////////////////////////////////////////////////
            CreateHostBuilder(args).Build().Run();
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
