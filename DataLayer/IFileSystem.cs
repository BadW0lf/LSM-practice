using System.Collections.Generic;
using DataLayer.MemoryHash;

namespace DataLayer
{
    public interface IFileSystem
    {
        void WriteOnDisk(Operation operation);
        void WriteOperationsOnDisk(IEnumerable<Operation> operations);

        void WriteSnapshot(MemoryHash.MemoryCopy memoryCopy);

        void WriteDiskTable(MemoryHash.MemoryCopy memoryCopy);
        IEnumerable<Operation> ReadOperationsWithOffset(int offset, int count);
        IEnumerable<Operation> ReadAllOperations();
        MemoryCopy ReadLastMemoryHash(IOperationLog operationLog);
    }
}