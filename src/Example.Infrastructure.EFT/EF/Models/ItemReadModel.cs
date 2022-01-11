namespace Example.Infrastructure.EFT.EF.Models
{
    internal class ItemReadModel
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public ItemNameReadModel ItemName { get; set; }
        public PriceReadModel Price { get; set; }
        private ItemTypeReadModel ItemType { get; set; }
        private DescriptionReadModel Description { get; set; }
    }
}
