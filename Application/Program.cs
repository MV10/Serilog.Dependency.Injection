using System;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Injection;
using External.Library;

namespace Serilog.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddExternalLibraryServices();
            services.AddSerilogServices();
            var provider = services.BuildServiceProvider();

            var log = provider.GetService<ILogger>();
            log.Information("ILogger service reference obtained.");

            var divider = provider.GetService<IDivideByZero>();
            divider.CrashThyself(999);

            log.Information("Ready to exit.");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

    }
}
