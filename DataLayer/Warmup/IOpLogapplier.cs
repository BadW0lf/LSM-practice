using DataLayer.MemoryCopy;

namespace DataLayer.Warmup
{
    public interface IOpLogApplier
    {
        void Apply(IMemTable memTable);
    }
}