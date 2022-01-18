using Example.Shared.EFT.Abstractions.Exceptions;

namespace Example.Core.EFT.Exceptions
{
    internal class EmptyIdException : EftCoreException
    {
        public EmptyIdException(string? message, string code) : base(message, code)
        {
        }
    }
}
