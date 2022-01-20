using Example.Core.EFT.Value_Object;

namespace Example.Core.EFT.Policies
{
    public interface IItemPolicy
    {
        bool IsApplicable(PolicyData data);
        Price Apply(PolicyData data);
    }
}
