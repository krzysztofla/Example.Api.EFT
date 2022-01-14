using Example.Core.EFT.Entities;
using Example.Core.EFT.Repositories;
using Example.Core.EFT.Value_Object;
using Example.Infrastructure.EFT.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.EFT.EF.Repository
{
    internal class CosmosDbRepository : IItemRepository
    {
        private readonly DbSet<Item> _items;
        private readonly WriteDbContext _writeContext;
             

        public CosmosDbRepository(WriteDbContext context)
        {
            _items = context.Items;
            _writeContext = context;
        }

        public async Task AddAsync(Item item, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> GetAsync(ItemId id, CancellationToken token) => _items.AsNoTracking().SingleOrDefault(i => i.Id == id);

        public async Task<IEnumerable<Item>> RemoveAsync(Item item, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> UpdateAsync(Item item, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
