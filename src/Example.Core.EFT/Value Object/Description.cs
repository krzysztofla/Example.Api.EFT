using Example.Core.EFT.Consts;
using Example.Core.EFT.Exceptions;
using Example.Shared.EFT.Abstractions.Exceptions;

namespace Example.Core.EFT.Value_Object
{
    public class Description
    {
        public string Value { get; }

        public Description(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyDescriptionException(ExceptionMessages.EmptyDescriptionValue, ErrorCodes.ExampleCode);
            }
            Value = value;
        }

        public static implicit operator string(Description description) => description.Value;

        public static implicit operator Description(string description) => new(description);

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
