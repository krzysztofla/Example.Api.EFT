using Example.Application.EFT.DTO;
using Example.Application.EFT.Queries;
using Example.Application.EFT.Services;
using Example.Shared.EFT.Queries;

namespace Example.Infrastructure.EFT.EF.Queries
{
    internal class GetItemHandler : IQueryHandler<GetItem, ItemDto>
    {
        private readonly IItemReadService _itemService;

        public GetItemHandler(IItemReadService itemsService) => _itemService = itemsService;

        public async Task<ItemDto> HandleAsync(GetItem query, CancellationToken token)
        {
            var item = await _itemService.GetAsync(query.Id);

            return item;
        }
    }
}
