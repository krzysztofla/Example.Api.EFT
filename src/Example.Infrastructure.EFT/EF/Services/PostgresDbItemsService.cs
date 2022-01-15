using Example.Application.EFT.DTO;
using Example.Application.EFT.Services;
using Example.Core.EFT.Value_Object;
using Example.Infrastructure.EFT.EF.Context;
using Example.Infrastructure.EFT.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.EFT.EF.Services
{
    internal class PostgresDbItemsService : IItemReadService
    {
        private readonly DbSet<ItemReadModel> _items;

        public PostgresDbItemsService(ReadDbContext context)
        {
            _items = context.Items;
        }

        public async Task<bool> CheckIfItemExistsAsync(string name)
        {
            return await _items.AnyAsync(i => i.ItemName.Value == name);
        }

        public Task<IEnumerable<ItemDto>> GetAsync(int minValue, int maxValue)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemDto>> GetAsync(ItemType type)
        {
            throw new NotImplementedException();
        }
    }
}
