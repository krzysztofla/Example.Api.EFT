namespace Example.Shared.EFT.Queries
{
    public interface IQueryHandler
    {
        Task<TResult> HandleAsync<TResult>(IQuery<TResult> query); 
    }
}
