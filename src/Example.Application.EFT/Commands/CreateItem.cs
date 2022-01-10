using Example.Shared.EFT.Commands;

namespace Example.Application.EFT.Commands
{
    public record CreateItem(Guid Id, string name, string description, PriceDataModel price, int itemType, string promoCode) : ICommand;

    public record PriceDataModel(int itemPrice, int currency);
}
