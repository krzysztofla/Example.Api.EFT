using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Example.Shared.EFT.Queries
{
    public static class Extensions
    {
        public static IServiceCollection RegisterQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(x => x.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
