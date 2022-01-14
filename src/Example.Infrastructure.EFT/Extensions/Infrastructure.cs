using Example.Infrastructure.EFT.EF;
using Example.Infrastructure.EFT.EF.Config;
using Example.Infrastructure.EFT.EF.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infrastructure.EFT.Extensions
{
    public static class Infrastructure
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCosmosDb(configuration);
            services.AddQueries();

            return services;
        }
    }
}
