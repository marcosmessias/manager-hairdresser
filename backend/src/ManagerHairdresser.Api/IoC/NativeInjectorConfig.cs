using ManagerHairdresser.Application.Interfaces.Services;
using ManagerHairdresser.Identity.Services;

namespace ManagerHairdresser.Api.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
