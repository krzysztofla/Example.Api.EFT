using Example.Core.EFT.Value_Object;
using Example.Shared.EFT.Domain;

namespace Example.Core.EFT.Events
{
    public record ItemTypeUpdated(ItemType type) : IDomainEvent;
}
