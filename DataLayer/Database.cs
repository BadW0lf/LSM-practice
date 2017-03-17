using System;
using DataLayer.DataModel;

namespace DataLayer
{
    // управляет memoryhash, disk tables, operationLog и управляет всеми запросами
    // а так же управляет мерджингом
    class Database
    {
        public void Add(Item item)
        {
            throw new NotImplementedException();
        }

        public void RestoreMemoryCopyFromSnapshot() { throw new NotImplementedException();}
    }
}