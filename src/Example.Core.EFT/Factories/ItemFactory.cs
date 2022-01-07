using Example.Core.EFT.Entities;
using Example.Core.EFT.Policies;
using Example.Core.EFT.Policies.Pricing;
using Example.Core.EFT.Value_Object;

namespace Example.Core.EFT.Factories
{
    internal class ItemFactory : IItemFactory
    {
        private readonly IEnumerable<IItemPolicy> _policies;

        public ItemFactory(IEnumerable<IItemPolicy> policies)
            => _policies = policies;

        public Item CreateItem(ItemId id, Price price, ItemType type, Description description) => new(id, price, type, description);

        public Item CreateItemWithPricePolicy(ItemId id, Price price, ItemType type, Description description)
        {
            var policyData = new PolicyData(price, type);
            var applicablePolicies = _policies.Where(p => p.IsApplicable(policyData) && p is IPricePolicy).ToList();
            var priceWithPollicies = new Price(0, Currency.RUB);

            foreach (var policy in applicablePolicies)
            { 
                priceWithPollicies = policy.Apply(policyData);
            }

            return new Item(id, priceWithPollicies, policyData.Type, description);
        }
    }
}
