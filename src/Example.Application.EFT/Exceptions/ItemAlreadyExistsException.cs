using Example.Shared.EFT.Abstractions.Exceptions;

namespace Example.Application.EFT.Exceptions
{
    internal class ItemAlreadyExistsException : EftCoreException
    {
        public ItemAlreadyExistsException(string? message, string code) : base(message, code)
        {
        }
    }
}
