using Example.Core.EFT.Entities;
using Example.Core.EFT.Value_Object;

namespace Example.Core.EFT.Factories
{
    public interface IItemFactory
    {
        Item CreateItem(ItemId id, Price price, ItemType type, Description description);
        Item CreateItemWithPricePolicy(ItemId id, Price price, ItemType type, Description description);
    }
}
