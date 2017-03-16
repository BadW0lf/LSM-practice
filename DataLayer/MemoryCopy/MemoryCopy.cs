using System;
using System.Collections.Generic;

namespace DataLayer.MemoryHash
{
    public class MemoryCopy
    {
        private readonly IOperationLog operationLog;
        private Dictionary<Guid, Item> memoryTable;

        public MemoryCopy(IOperationLog operationLog)
        {
            this.operationLog = operationLog;
            memoryTable = new Dictionary<Guid, Item>();
            
           
            // заполнить из OperationLog
        }

        public void Add(Guid id, Item item)
        {
            
        }

        public Item Get(Guid id)
        {
            return memoryTable[id];
        }
    }
}