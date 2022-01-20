using Example.Infrastructure.EFT.EF;
using Example.Infrastructure.EFT.EF.Queries;
using Example.Infrastructure.EFT.Logging;
using Example.Shared.EFT.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infrastructure.EFT.Extensions
{
    public static class Infrastructure
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingDecorator<>));
            services.AddPostgresDb(configuration);
            services.AddQueries();

            return services;
        }
    }
}
