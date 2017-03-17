using DataLayer.DataModel;

namespace DataLayer.MemoryCopy
{
    public interface IMemTable
    {
        void Add(Item item);

        Item Get(string key);
    }
}