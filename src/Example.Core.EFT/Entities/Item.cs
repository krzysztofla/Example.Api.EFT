using Example.Core.EFT.Value_Object;
using Example.Shared.EFT.Domain;

namespace Example.Core.EFT.Entities
{
    internal class Item : AggregateRoot<Guid>
    {
        public Guid id { get; private set; }
        private readonly Price _price;

        private readonly Description _description;

        public Item(Guid id, Price price, Description description)
        {
            id = id;
            _price = price;
            _description = description;
        }
    }
}
