using DataLayer.OperationLog.Operations;
using DataLayer.Utilities;

namespace DataLayer
{
    public class OpLogManager : IOpLogReader, IOpLogWriter
    {
        private readonly IFile olFile;
        private readonly IOperationSerializer serializer;

        public OpLogManager(IFile olFile, IOperationSerializer serializer)
        {
            this.olFile = olFile;
            this.serializer = serializer;
        }

        public bool Read(out IOperation operation)
        {
            throw new System.NotImplementedException();
        }

        public void Write(IOperation operation)
        {
            throw new System.NotImplementedException();
        }
    }
}