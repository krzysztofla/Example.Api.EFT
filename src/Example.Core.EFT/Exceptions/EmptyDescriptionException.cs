namespace Example.Core.EFT.Exceptions
{
    internal class EmptyDescriptionException : DomainException
    {
        public EmptyDescriptionException(string? message) : base(message)
        {

        }
    }
}
