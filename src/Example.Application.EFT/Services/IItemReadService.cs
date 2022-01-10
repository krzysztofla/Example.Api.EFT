using Example.Core.EFT.Entities;
using Example.Core.EFT.Value_Object;

namespace Example.Application.EFT.Services
{
    public interface IItemReadService
    {
        Task<bool> CheckIfItemExistsAsync(string name);
        Task<IEnumerable<Item>> GetAsync(int minValue, int maxValue);
        Task<IEnumerable<Item>> GetAsync(ItemType type);
    }
}
