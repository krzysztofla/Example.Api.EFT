namespace Example.Core.EFT.Value_Object
{
    public record ItemName
    {
        public string Value { get; }
        public ItemName(string name)
        {
            Value = name;
        }

        public static implicit operator string(ItemName name) => name.Value;

        public static implicit operator ItemName(string name) => new(name);
    }
}
