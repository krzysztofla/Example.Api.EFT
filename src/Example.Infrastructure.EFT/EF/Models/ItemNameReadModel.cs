namespace Example.Infrastructure.EFT.EF.Models
{
    internal class ItemNameReadModel
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static ItemNameReadModel Build(string name)
        {
            return new ItemNameReadModel()
            {
                Value = name
            };
        }
    }
}
