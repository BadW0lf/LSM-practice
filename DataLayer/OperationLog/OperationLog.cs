using System.Collections.Generic;

namespace DataLayer
{
    public class OperationLog : IOperationLog
    {
        private readonly IFileSystem fileSystem;

        public OperationLog(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public void Add(Operation operation)
        {
            fileSystem.WriteOnDisk(operation);
        }

        public IEnumerable<Operation> Read(int offset, int count)
        {
            return fileSystem.ReadFromDisk(offset, count);
        }
    }
}