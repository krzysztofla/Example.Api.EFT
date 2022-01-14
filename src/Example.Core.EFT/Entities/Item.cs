using Example.Core.EFT.Events;
using Example.Core.EFT.Value_Object;
using Example.Shared.EFT.Domain;

namespace Example.Core.EFT.Entities
{
    public class Item : AggregateRoot<ItemId>
    {
        public ItemId Id { get; private set; }

        private ItemName _name;
        private Price _price;
        private ItemType _type;
        private Description _description;

        private Item()
        {

        }

        internal Item(ItemId id, ItemName name, Price price, ItemType type, Description description) : this(id, name, description)
        {
            _price = price;
            _type = type;
        }

        internal Item(ItemId id, ItemName name, Description description)
        {
            Id = id;
            _name = name;
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
