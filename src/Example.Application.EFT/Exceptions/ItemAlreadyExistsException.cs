namespace Example.Application.EFT.Exceptions
{
    internal class ItemAlreadyExistsException : Exception
    {
        public ItemAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
