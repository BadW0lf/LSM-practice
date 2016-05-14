using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class OperationLog : IOperationLog
    {
        private readonly IFileSystem fileSystem;
        private readonly List<Operation> operations;
        private const int OperationsInMemoryLimit = 100;

        public OperationLog(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            operations = new List<Operation>();
        }

        public void Add(Operation operation)
        {
            //fileSystem.WriteOnDisk(operation);
            if (operations.Count + 1 <= OperationsInMemoryLimit)
                operations.Add(operation);
            else
                throw new OutOfMemoryException();
            
        }

        public IEnumerable<Operation> Read(int offset, int count)
        {
            if (count > operations.Count)
                return Enumerable.Empty<Operation>();
            return operations.GetRange(offset, Math.Min(count, operations.Count - offset));
        }
    }
}