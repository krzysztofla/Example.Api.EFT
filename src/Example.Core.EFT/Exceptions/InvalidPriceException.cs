namespace Example.Core.EFT.Exceptions
{
    internal class InvalidPriceException : DomainException
    {
        public InvalidPriceException(string? message) : base(message)
        {
        }
    }
}
