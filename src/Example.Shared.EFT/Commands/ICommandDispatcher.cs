namespace Example.Shared.EFT.Commands
{
    public interface ICommandDispatcher
    {
       public Task DispatchAsync<TCommand>(TCommand command, CancellationToken token) where TCommand : class, ICommand;
    }
}
