using Example.Application.EFT.DTO;
using Example.Shared.EFT.Queries;

namespace Example.Application.EFT.Queries
{
    public class GetPage : IQuery<List<ItemDto>>
    {
        public int Page { get; set {
                        if (value == 0) {
                Page = 1;
            }
        } } = 1;
    }
}
