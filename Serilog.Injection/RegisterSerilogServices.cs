using Microsoft.Extensions.DependencyInjection;
using System;

namespace Serilog.Injection
{
    public static class RegisterSerilogServices
    {
        public static IServiceCollection AddSerilogServices(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithProperty("PropertyName", "PropertyValue")
                .WriteTo.Console()
                .WriteTo.MSSqlServer(@"xxxxxxxxxxxxx", "Logs")
                .CreateLogger();

            AppDomain.CurrentDomain.ProcessExit += (s, e) => CloseAndFlush();

            return services.AddSingleton(Log.Logger);
        }

        private static void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }
    }
}
