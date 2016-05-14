using System.Collections.Generic;

namespace DataLayer
{
    public interface IFileSystem
    {
        void WriteOnDisk(Operation operation);
        void WriteOperationsOnDisk(IEnumerable<Operation> operations);
        void WriteSnapshot(MemoryHash.MemoryHash memoryHash);
        void WriteDiskTable(MemoryHash.MemoryHash memoryHash);

        IEnumerable<Operation> ReadFromDisk(int offset, int count);

    }
}