using Example.Application.EFT.DTO;
using Example.Application.EFT.Queries;
using Example.Infrastructure.EFT.EF.Context;
using Example.Infrastructure.EFT.EF.Models;
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
            var item = _items.Where(i => i.Id == query.Id).Select(i => new ItemDto()
            {
                Id = i.Id,
                Name = i.ItemName.Value,
                Price = i.Price.Value.ToString(),
                Description =i.Description.Value,
            }).SingleOrDefault();
            return item;
        }
    }
}
