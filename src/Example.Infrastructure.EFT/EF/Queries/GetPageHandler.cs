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
    internal class GetPageHandler : IQueryHandler<GetPage, List<ItemDto>>
    {
        private readonly DbSet<ItemReadModel> _items;

        public GetPageHandler(ReadDbContext context)
        {
            _items = context.Items;
        }

        public async Task<List<ItemDto>> HandleAsync(GetPage query, CancellationToken token)
        {
            var pageSize = 50;

            if (query.Page == 0) {
                query.Page = 1;
            }

            var items = await _items.Skip((query.Page -1) * pageSize).Take(pageSize).ToListAsync();

            var itemDtos = items.Select(i => new ItemDto()
            {
                Id = i.Id,
                Name = i.ItemName,
                Price = i.Price.Value.ToString(),
                Description =i.Description,
            }).ToList();

            return itemDtos;
        }
    }
}
