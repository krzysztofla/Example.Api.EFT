using Example.Core.EFT.Consts;
using Example.Core.EFT.Exceptions;

namespace Example.Core.EFT.Value_Object
{
    internal class Description
    {
        public string Value { get; }

        public Description(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyDescriptionException(ExceptionMessages.EmptyDescriptionValue);
            }
            Value = value;
        }
    }
}
