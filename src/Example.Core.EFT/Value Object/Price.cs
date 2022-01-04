
using Example.Core.EFT.Consts;
using Example.Core.EFT.Exceptions;

namespace Example.Core.EFT.Value_Object
{
    internal record Price
    {
        public long Value { get; }
        public Currency Currency { get; }

        public Price(long price, Currency currency)
        {
            Value = SetPrice(price);
            Currency = SetCurrency(currency);
        }

        private Currency SetCurrency(Currency currency)
        {
            return currency;
        }

        private long SetPrice(long price)
        {
            if(price <= 0 )
            {
                throw new InvalidPriceException(ExceptionMessages.InvalidPriceValue);
            }
            return price;
        }
    }
}
