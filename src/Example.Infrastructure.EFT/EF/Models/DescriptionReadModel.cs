namespace Example.Infrastructure.EFT.EF.Models
{
    internal class DescriptionReadModel
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static DescriptionReadModel Build(string description)
        {
            return new DescriptionReadModel()
            {
                Value = description
            };
        }
    }
}
