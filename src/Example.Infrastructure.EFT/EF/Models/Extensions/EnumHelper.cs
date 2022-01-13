namespace Example.Infrastructure.EFT.EF.Models.Extensions
{
    internal static class EnumHelper
    {
        /// <summary>
        /// ItemTypeReadModel enum fast conversion to string
        /// </summary>
        /// <param name="cases">ItemTypeReadModel</param>
        /// <returns>String</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ToString(ItemTypeReadModel cases)
        {
            switch (cases)
            {
                case ItemTypeReadModel.Materials:
                    return nameof(ItemTypeReadModel.Materials);
                case ItemTypeReadModel.Weapon:
                    return nameof(ItemTypeReadModel.Weapon);
                case ItemTypeReadModel.Special:
                    return nameof(ItemTypeReadModel.Special);
                case ItemTypeReadModel.Ammo:
                    return nameof(ItemTypeReadModel.Ammo);
                case ItemTypeReadModel.Helmet:
                    return nameof(ItemTypeReadModel.Helmet);
                case ItemTypeReadModel.Armor:
                    return nameof(ItemTypeReadModel.Armor);
                default:
                    throw new ArgumentOutOfRangeException(nameof(cases), cases, null);
            }
        }

        /// <summary>
        /// CurrencyReadModel enum fast conversion to string
        /// </summary>
        /// <param name="cases"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ToString(CurrencyReadModel cases)
        {
            switch (cases)
            {
                case CurrencyReadModel.PLN:
                    return nameof(CurrencyReadModel.PLN);
                case CurrencyReadModel.RUB:
                    return nameof(CurrencyReadModel.RUB);
                case CurrencyReadModel.USD:
                    return nameof(CurrencyReadModel.USD);
                default:
                    throw new ArgumentOutOfRangeException(nameof(cases), cases, null);
            }
        }
    }
}
