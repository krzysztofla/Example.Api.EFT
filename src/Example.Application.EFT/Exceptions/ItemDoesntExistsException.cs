using Example.Shared.EFT.Abstractions.Exceptions;

namespace Example.Application.EFT.Exceptions
{
    internal class ItemDoesntExistsException : EftCoreException
    {
        public ItemDoesntExistsException(string? message, string code) : base(message, code)
        {
        }
    }
}
