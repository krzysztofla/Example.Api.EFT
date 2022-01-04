namespace Example.Core.EFT.Exceptions
{
    internal class DomainException : Exception
    {
        public DomainException(string? message) : base(message)
        {

        }
    }
}
