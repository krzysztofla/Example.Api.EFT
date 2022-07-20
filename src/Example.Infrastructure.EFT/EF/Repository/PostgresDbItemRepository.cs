using Example.Core.EFT.Entities;
using Example.Core.EFT.Repositories;
using Example.Core.EFT.Value_Object;
using Example.Infrastructure.EFT.Consts;
using Example.Infrastructure.EFT.EF.Context;
using Example.Infrastructure.EFT.Exceptions;
using Example.Shared.EFT.Abstractions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.EFT.EF.Repository
{
    internal class PostgresDbItemRepository : IItemRepository
    {
        private readonly DbSet<Item> _items;
        private readonly WriteDbContext _writeContext;


        public PostgresDbItemRepository(WriteDbContext context)
        {
            _items = context.Items;
            _writeContext = context;
        }

        public async Task AddAsync(Item item, CancellationToken token)
        {
            await _items.AddAsync(item);
            await _writeContext.SaveChangesAsync();
        }

        public async Task<Item> GetAsync(ItemId id, CancellationToken token)
        {
            var item = await _items.AsNoTracking().SingleOrDefaultAsync(i => i.Id == id);

            if (item is null)
            {
                throw new ItemDoesntExistsException(ExceptionMessages.ItemDoesntExist, ErrorCodes.ExampleCode);
            }

            return item;
        }

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
