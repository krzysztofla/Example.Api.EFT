using Example.Shared.EFT.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infrastructure.EFT.EF.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.RegisterQueries();
            return services;
        }
    }
}
