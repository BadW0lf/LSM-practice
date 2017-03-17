using DataLayer.OperationLog.Operations;

namespace DataLayer
{
    public interface IOpLogReader
    {
        /// <summary>
        /// Reads operations from operation log. </summary>
        /// <returns>
        /// Returns false when nothing more to read, otherwise true</returns>
        bool Read(out IOperation operation);
    }
}