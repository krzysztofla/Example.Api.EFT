namespace Example.Infrastructure.EFT.EF.Models
{
    internal class PriceReadModel
    {
        public int Value { get; set; }
        public CurrencyReadModel Currency { get; set; }

        public override string ToString()
        {
            return $"{Value},{Currency}";
        }

        public static PriceReadModel Build(string price)
        {
            var priceValues = price.Split(',');

            return new PriceReadModel()
            {
                Value = int.Parse(priceValues.First()),
                Currency = Enum.Parse<CurrencyReadModel>(priceValues.Last())
            };
        }
    }
}

