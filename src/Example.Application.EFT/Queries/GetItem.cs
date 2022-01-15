using Example.Application.EFT.DTO;
using Example.Shared.EFT.Queries;

namespace Example.Application.EFT.Queries
{
    public class GetItem : IQuery<ItemDto>
    {
        public Guid Id { get; set; }
    }
}
