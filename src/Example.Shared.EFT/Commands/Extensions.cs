using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Example.Shared.EFT.Commands
{
    public static class Extensions
    {
        public static IServiceCollection RegisterCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(x => x.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
