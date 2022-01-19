using Example.Shared.EFT.Middleware;
using Example.Shared.EFT.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Shared.EFT
{
    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
            services.AddHostedService<AppInitializer>();
            return services;
        }

        public static IApplicationBuilder UseShared(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
            return builder;
        }
    }
}
