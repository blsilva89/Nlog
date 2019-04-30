using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NlogConsole.Common;
using System;

namespace NlogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var config = new ConfigurationBuilder()
                   .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .Build();

                var servicesProvider = BuildDi(config);
                using (servicesProvider as IDisposable)
                {
                    var runner = servicesProvider.GetRequiredService<Runner>();
                    runner.DoAction("Action1");

                    Console.WriteLine("Press ANY key to exit");                    
                }
            }
            catch (Exception ex)
            {
                // NLog: catch any exception and log it.
                //logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                //LogManager.Shutdown();
            }
        }

        private static IServiceProvider BuildDi(IConfiguration config)
        {
            return new ServiceCollection()
               .AddScoped<Runner>() // Runner is the custom class
               .AddSingleton<ILog, LogNLog>()
               .BuildServiceProvider();
        }
    }
}
