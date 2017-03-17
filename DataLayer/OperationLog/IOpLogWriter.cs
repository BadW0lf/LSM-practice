using DataLayer.OperationLog.Operations;

namespace DataLayer
{
    public interface IOpLogWriter
    {
        void Write(IOperation operation);
    }
}