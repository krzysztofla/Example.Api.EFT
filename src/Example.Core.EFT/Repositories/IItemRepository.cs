using Example.Core.EFT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core.EFT.Repositories
{
    internal interface IItemRepository
    {
        Task<Item> GetItemByNameAsync(string name);

        Task<Item> GetItemByIdAsync(Guid id);

        Task<IEnumerable<Item>> GetItemsByPriceRange(int minValue, int maxValue);

        Task<IEnumerable<Item>> GetItemsByType();
    }
}
