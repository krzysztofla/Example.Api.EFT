using Example.Core.EFT.Value_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core.EFT.Entities
{
    internal class Item
    {
        public Guid id { get; private set; }    
        private readonly Price _price;

        private readonly Description _description;

        public Item(Guid id, Price price, Description description)
        {
            id = id;
            _price = price;
            _description = description;
        }
    }
}
