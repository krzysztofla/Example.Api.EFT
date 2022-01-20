using Example.Shared.EFT.Commands;
using Microsoft.Extensions.Logging;

namespace Example.Infrastructure.EFT.Logging
{
    internal class LoggingDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        private ICommandHandler<TCommand> _commandHandler;
        private ILogger<LoggingDecorator<TCommand>> _logger;

        public LoggingDecorator(ICommandHandler<TCommand> commandHandler, ILogger<LoggingDecorator<TCommand>> logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }

        public async Task HandleAsync(TCommand command, CancellationToken token)
        {
            try
            {
                _logger.LogInformation($"Example information for {command}");
                await _commandHandler.HandleAsync(command, token);
            }
            catch (Exception)
            {
                _logger.LogError("Error from logging decorator");
                throw;
            }
        }
    }
}
