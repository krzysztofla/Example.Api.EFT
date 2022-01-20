using Example.Shared.EFT.Abstractions.Exceptions;

namespace Example.Core.EFT.Exceptions
{
    internal class EmptyDescriptionException : EftCoreException
    {
        public EmptyDescriptionException(string? message, string code) : base(message, code)
        {

        }
    }
}
