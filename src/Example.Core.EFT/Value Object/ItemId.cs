using Example.Core.EFT.Consts;
using Example.Core.EFT.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core.EFT.Value_Object
{
    internal record ItemId
    {
        public Guid Value { get; protected set; }

        public ItemId(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new EmptyIdException(ExceptionMessages.EmptyIdValue);
            }
            Value = id;

        }

        public static implicit operator Guid(ItemId id) => id.Value;

        public static implicit operator ItemId(Guid id) => new(id);
    }
}
