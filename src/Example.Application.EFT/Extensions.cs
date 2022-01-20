using Example.Core.EFT.Factories;
using Example.Shared.EFT.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Application.EFT
{
    public static class Extensions
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddSingleton<IItemFactory, ItemFactory>();

            services.RegisterCommands();
            return services;
        }
    }
}
