using Example.Core.EFT.Events;
using Example.Core.EFT.Value_Object;
using Example.Shared.EFT.Domain;

namespace Example.Core.EFT.Entities
{
    internal class Item : AggregateRoot<ItemId>
    {
        public ItemId _id { get; private set; }
        
        private Price _price;
        private ItemType _type;
        private Description _description;

        internal Item(Guid id, Price price, ItemType type, Description description)
        {
            _id = id;
            _price = price;
            _type = type;
            _description = description;
        }

        public void UpdatePrice(Price price)
        {
            _price = price;
            AddEvent(new ItemPriceUpdated(_price));
        }

        public void UpdateType(ItemType type)
        {
            _type = type;
            AddEvent(new ItemTypeUpdated(_type));
        }

        public void UpdateDescription(Description description)
        {
            _description = description;
            AddEvent(new ItemDescriptionUpdated(_description));
        }
    }
}
