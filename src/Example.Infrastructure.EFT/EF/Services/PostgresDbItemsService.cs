using Example.Application.EFT.DTO;
using Example.Application.EFT.Services;
using Example.Core.EFT.Value_Object;
using Example.Infrastructure.EFT.Consts;
using Example.Infrastructure.EFT.EF.Context;
using Example.Infrastructure.EFT.EF.Models;
using Example.Infrastructure.EFT.Exceptions;
using Example.Shared.EFT.Abstractions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.EFT.EF.Services
{
    internal class PostgresDbItemsService : IItemReadService, IItemWriteService
    {
        private readonly DbSet<ItemReadModel> _items;

        public PostgresDbItemsService(ReadDbContext context)
        {
            _items = context.Items;
        }

        public async Task<bool> CheckIfItemExistsAsync(string name)
        {

            var exist = await _items.AnyAsync(i => i.ItemName == name);
            if (!exist)
            {
                throw new ItemDoesntExistsException(ExceptionMessages.ItemDoesntExist, ErrorCodes.ExampleCode);
            }
            return exist;
        }
        public async Task<bool> CheckIfItemExistsAsync(Guid id)
        {
            var exist = await _items.AnyAsync(i => i.Id == id);
            if (!exist)
            {
                throw new ItemDoesntExistsException(ExceptionMessages.ItemDoesntExist, ErrorCodes.ExampleCode);
            }
            return exist;
        }

        public async Task<ItemDto> GetAsync(Guid id)
        {
            var exists = await CheckIfItemExistsAsync(id);

            if (!exists)
            {
                throw new ItemDoesntExistsException(ExceptionMessages.ItemDoesntExist, ErrorCodes.ExampleCode);
            }

            var item = _items.Where(i => i.Id == id).Select(i => new ItemDto()
            {
                Id = i.Id,
                Name = i.ItemName,
                Price = i.Price.Value.ToString(),
                Description = i.Description,
            }).SingleOrDefault();

            return item;
        }

        public Task<IEnumerable<ItemDto>> GetAsync(ItemType type)
        {
            throw new NotImplementedException();
        }
    }
}
