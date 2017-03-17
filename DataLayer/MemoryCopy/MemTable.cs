using DataLayer.DataModel;

namespace DataLayer.MemoryCopy
{
    public class MemTable : IMemTable
    {
        private readonly IOpLogWriter opLogWriter;

        public MemTable(IOpLogWriter opLogWriter)
        {
            this.opLogWriter = opLogWriter;
        }

        public void Add(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Item Get(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}