using Example.Application.EFT.DTO;
using Example.Shared.EFT.Queries;

namespace Example.Application.EFT.Queries
{
    public class ListItems : IQuery<List<ItemDto>>
    {
        public int Page { get; set; } = 0;

        public int PageSize {get; set; } = 50;
    }
}
