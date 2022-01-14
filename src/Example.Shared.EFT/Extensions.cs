using Example.Shared.EFT.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Shared.EFT
{
    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddHostedService<AppInitializer>();
            return services;
        }
    }
}
