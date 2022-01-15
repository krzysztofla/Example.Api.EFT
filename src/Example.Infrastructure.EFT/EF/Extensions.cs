using Example.Application.EFT.Services;
using Example.Core.EFT.Repositories;
using Example.Infrastructure.EFT.EF.Config;
using Example.Infrastructure.EFT.EF.Context;
using Example.Infrastructure.EFT.EF.Repository;
using Example.Infrastructure.EFT.EF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infrastructure.EFT.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddCosmosDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IItemReadService, PostgresDbItemsService>();
            services.AddScoped<IItemRepository, PostgresDbItemRepository>();

            var postgresDbOptions = new PostgresDbOptions();
            configuration.GetSection("PostgresDb").Bind(postgresDbOptions);

            services.AddDbContext<ReadDbContext>(p => p.UseNpgsql(postgresDbOptions.ConnectionString));
            services.AddDbContext<WriteDbContext>(p => p.UseNpgsql(postgresDbOptions.ConnectionString));

            return services;
        }
    }
}
