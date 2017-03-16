using System.Collections.Generic;

namespace DataLayer
{
    //учесть что надо прыгать по определённому офсету в бинарно сериализованном файле
    // ветки с решенными этапами локально держат
    public interface IOperationLog
    {
        void Add(Operation operation);
        IEnumerable<Operation> Read(int offset, int count);
        IEnumerable<Operation> ReadAll();
    }
}