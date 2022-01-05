
using Example.Core.EFT.Consts;
using Example.Core.EFT.Exceptions;

namespace Example.Core.EFT.Value_Object
{
    internal record Price
    {
        public int Value { get; }
        public Currency Currency { get; }

        public Price(int price, Currency currency)
        {
            Value = SetPrice(price);
            Currency = SetCurrency(currency);
        }

        private Currency SetCurrency(Currency currency)
        {
            return currency;
        }

        private int SetPrice(int price)
        {
            if(price <= 0 )
            {
                throw new InvalidPriceException(ExceptionMessages.InvalidPriceValue);
            }
            return price;
        }
    }
}
