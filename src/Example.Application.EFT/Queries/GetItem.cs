using Example.Application.EFT.DTO;
using Example.Shared.EFT.Queries;

namespace Example.Application.EFT.Queries
{
    public record GetItem(Guid Id, string name, MinMax minMax, int type) : IQuery<ItemDto>;

    public record MinMax(int min, int max);
}
