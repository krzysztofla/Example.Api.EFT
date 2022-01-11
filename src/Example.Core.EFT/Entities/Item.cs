using Example.Core.EFT.Events;
using Example.Core.EFT.Value_Object;
using Example.Shared.EFT.Domain;

namespace Example.Core.EFT.Entities
{
    public class Item : AggregateRoot<ItemId>
    {
        public ItemId _id { get; private set; }

        private ItemName _name;
        private Price _price;
        private ItemType _type;
        private Description _description;

        private Item()
        {

        }

        internal Item(Guid id, ItemName name, Price price, ItemType type, Description description)
        {
            _id = id;
            _name = name;
            _price = price;
            _type = type;
            _description = description;
        }

        public void UpdatePrice(Price price)
        {
            _price = price;
            AddEvent(new ItemPriceUpdated(_price));
        }

        public void UpdateName(ItemName name)
        {
            _name = name;
            AddEvent(new ItemNameUpdated(_name));
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
