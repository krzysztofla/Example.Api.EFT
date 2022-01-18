using Example.Shared.EFT.Abstractions.Exceptions;

namespace Example.Core.EFT.Exceptions
{
    internal class InvalidPriceException : EftCoreException
    {
        public InvalidPriceException(string? message, string code) : base(message, code)
        {
        }
    }
}
