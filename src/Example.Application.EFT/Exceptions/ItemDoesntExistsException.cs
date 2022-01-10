namespace Example.Application.EFT.Exceptions
{
    internal class ItemDoesntExistsException : Exception
    {
        public ItemDoesntExistsException(string? message) : base(message)
        {
        }
    }
}
