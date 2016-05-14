using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class FileSystem : IFileSystem
    {
        private readonly List<Operation> storedOperations;

        public FileSystem()
        {
            storedOperations = new List<Operation>();
        }

        public void WriteOnDisk(Operation operation)
        {
            storedOperations.Add(operation);
        }

        public void WriteOperationsOnDisk(IEnumerable<Operation> operations)
        {
            storedOperations.AddRange(operations);
        }

        public void WriteSnapshot(MemoryHash.MemoryHash memoryHash)
        {
            throw new System.NotImplementedException();
        }

        public void WriteDiskTable(MemoryHash.MemoryHash memoryHash)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Operation> ReadFromDisk(int offset, int count)
        {
            if (count > storedOperations.Count)
                return Enumerable.Empty<Operation>();
            return storedOperations.GetRange(offset, Math.Min(count, storedOperations.Count - offset));
        }
    }
}