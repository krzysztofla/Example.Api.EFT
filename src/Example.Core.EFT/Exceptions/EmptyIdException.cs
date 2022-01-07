namespace Example.Core.EFT.Exceptions
{
    internal class EmptyIdException : DomainException
    {
        public EmptyIdException(string? message) : base(message)
        {
        }
    }
}
