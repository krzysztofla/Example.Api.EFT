using Example.Core.EFT.Value_Object;

namespace Example.Core.EFT.Policies.Pricing
{
    internal record PricePolicy : IItemPolicy
    {
        public Price Apply(PolicyData data) => new(data.Price.Value - 100, Currency.RUB);

        public bool IsApplicable(PolicyData data) => data.Type is ItemType.Special;
    }
}
