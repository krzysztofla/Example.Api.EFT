using Example.Core.EFT.Entities;

namespace Example.Core.EFT.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetAsync(Guid id, CancellationToken token);

        Task AddAsync(Item item, CancellationToken token);

        Task<IEnumerable<Item>> UpdateAsync(Item item, CancellationToken token);

        Task<IEnumerable<Item>> RemoveAsync(Item item, CancellationToken token);
    }
}
