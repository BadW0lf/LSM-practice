using System.IO;

namespace DataLayer.OperationLog.Operations
{
    public interface IOperationSerializer
    {
        byte[] Serialize(IOperation operation);

        IOperation Deserialize(Stream opLogStream);
    }
}