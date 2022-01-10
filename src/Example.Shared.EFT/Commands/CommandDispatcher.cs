using Microsoft.Extensions.DependencyInjection;

namespace Example.Shared.EFT.Commands
{
    internal sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken token) where TCommand : class, ICommand
        {
            using var service = _serviceProvider.CreateScope();
            var handler = service.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.HandleAsync(command, token);
        }
    }

}
