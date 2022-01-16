namespace Example.Infrastructure.EFT.EF.Models
{
    internal class ItemReadModel
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string ItemName { get; set; }
        public PriceReadModel Price { get; set; }
        public ItemTypeReadModel ItemType { get; set; }
        public string Description { get; set; }


    }
}
