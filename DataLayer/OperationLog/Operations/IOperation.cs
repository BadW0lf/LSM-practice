using DataLayer.MemoryCopy;

namespace DataLayer.OperationLog.Operations
{
    public interface IOperation
    {
        void Apply(IMemTable memTable);
    }
}