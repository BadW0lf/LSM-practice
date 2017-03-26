using System;
using System.IO;
using DataLayer.DataModel;
using DataLayer.MemoryCopy;

namespace DataLayer
{
    // управляет memoryhash, disk tables, operationLog и управляет всеми запросами
    // а так же управляет мерджингом
    public class DatabaseManager
    {
        private readonly IMemTable memTable;
        private readonly DiskTablesMerger diskTablesMerger;
        private readonly DirectoryInfo databaseDirectory;

        public DatabaseManager(IMemTable memTable, DiskTablesMerger diskTablesMerger, DirectoryInfo databaseDirectory, MergeMethod mergeMethod)
        {
            this.memTable = memTable;
            this.diskTablesMerger = diskTablesMerger;
            this.databaseDirectory = databaseDirectory;
            MergeMethod = mergeMethod;

            ItemsTreshold = 10;
        }

        public void Add(Item item)
        {
            throw new NotImplementedException();
        }

        public void RestoreMemoryCopyFromSnapshot() { throw new NotImplementedException();}

        public int ItemsTreshold { get; private set; }
        public MergeMethod MergeMethod { get; }
    }

    public enum MergeMethod
    {
        MergeBySize, MergeByLevel
    }
}