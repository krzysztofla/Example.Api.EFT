using Example.Application.EFT.DTO;
using Example.Application.EFT.Queries;
using Example.Infrastructure.EFT.Consts;
using Example.Infrastructure.EFT.EF.Context;
using Example.Infrastructure.EFT.EF.Models;
using Example.Infrastructure.EFT.Exceptions;
using Example.Shared.EFT.Abstractions.Exceptions;
using Example.Shared.EFT.Queries;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.EFT.EF.Queries
{
    internal class GetItemHandler : IQueryHandler<GetItem, ItemDto>
    {
        private readonly DbSet<ItemReadModel> _items;

        public GetItemHandler(ReadDbContext context)
        {
            _items = context.Items;
        }

        public async Task<ItemDto> HandleAsync(GetItem query, CancellationToken token)
        {
            var exists = await _items.AnyAsync(i => i.Id == query.Id);

            if (exists)
            {
                throw new ItemDoesntExistsException(ExceptionMessages.ItemDoesntExist, ErrorCodes.ExampleCode);
            }

            var item = _items.Where(i => i.Id == query.Id).Select(i => new ItemDto()
            {
                Id = i.Id,
                Name = i.ItemName,
                Price = i.Price.Value.ToString(),
                Description =i.Description,
            }).SingleOrDefault();
            return item;
        }
    }
}
