using Example.Core.EFT.Entities;

namespace Example.Core.EFT.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetAsync(string name);

        Task<Item> GetAsync(Guid id);

        Task<IEnumerable<Item>> GetAsync(int minValue, int maxValue);

        Task<IEnumerable<Item>> GetAsync(Type type);

        Task<IEnumerable<Item>> AddAsync(Item item);

        Task<IEnumerable<Item>> UpdateAsync(Item item);

        Task<IEnumerable<Item>> RemoveAsync(Item item);
    }
}
