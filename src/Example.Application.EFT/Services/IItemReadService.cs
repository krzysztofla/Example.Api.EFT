using Example.Application.EFT.DTO;
using Example.Core.EFT.Value_Object;

namespace Example.Application.EFT.Services
{
    public interface IItemReadService
    {
        Task<bool> CheckIfItemExistsAsync(string name);
        Task<ItemDto> GetAsync(Guid id);
        Task<IEnumerable<ItemDto>> GetAsync(ItemType type);
    }
}
