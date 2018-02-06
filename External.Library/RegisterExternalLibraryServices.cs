using Microsoft.Extensions.DependencyInjection;

namespace External.Library
{
    public static class RegisterExternalLibraryServices
    {
        public static IServiceCollection AddExternalLibraryServices(this IServiceCollection services)
        {
            return services.AddTransient<IDivideByZero, DivideByZero>();
        }
    }
}
