
using Example.Core.EFT.Consts;
using Example.Core.EFT.Exceptions;
using Example.Shared.EFT.Abstractions.Exceptions;

namespace Example.Core.EFT.Value_Object
{
    public record Price
    {
        public int Value { get; }
        public Currency Currency { get; }

        public Price(int price, Currency currency)
        {
            Value = SetPrice(price);
            Currency = SetCurrency(currency);
        }

        public override string ToString()
        {
            return $"{Value},{Currency}";
        }

        public static Price Build(string price)
        {
            var priceValues = price.Split(',');
            var value = int.Parse(priceValues.Last());
            var currency = (Currency)int.Parse(priceValues.Last());
            return new Price(value, currency);
        }

        private Currency SetCurrency(Currency currency)
        {
            return currency;
        }

        private int SetPrice(int price)
        {
            if (price <= 0)
            {
                throw new InvalidPriceException(ExceptionMessages.InvalidPriceValue, ErrorCodes.ExampleCode);
            }
            return price;
        }


    }
}
