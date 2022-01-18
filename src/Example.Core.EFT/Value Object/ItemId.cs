using Example.Core.EFT.Consts;
using Example.Core.EFT.Exceptions;
using Example.Shared.EFT.Abstractions.Exceptions;

namespace Example.Core.EFT.Value_Object
{
    public record ItemId
    {
        public Guid Value { get; }

        public ItemId(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new EmptyIdException(ExceptionMessages.EmptyIdValue, ErrorCodes.ExampleCode);
            }
            Value = id;
        }

        public static implicit operator Guid(ItemId id) => id.Value;

        public static implicit operator ItemId(Guid id) => new(id);
    }
}
