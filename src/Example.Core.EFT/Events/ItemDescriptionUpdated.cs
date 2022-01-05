using Example.Core.EFT.Value_Object;
using Example.Shared.EFT.Domain;

namespace Example.Core.EFT.Events
{
    internal record ItemDescriptionUpdated(Description description): IDomainEvent;
}
