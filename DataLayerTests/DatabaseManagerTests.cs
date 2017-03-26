using System;
using System.IO;
using System.Reflection;
using DataLayer;
using DataLayer.DataModel;
using DataLayer.MemoryCopy;
using NSubstitute;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    public class DatabaseManagerTests
    {
        private DatabaseManager databaseManager;
        private IMemTable memTable;
        private DiskTablesMerger diskTablesMerger;
        private DirectoryInfo databaseDirectory;
        private MergeMethod method;

        [SetUp]
        public void SetUp()
        {
            databaseDirectory = new DirectoryInfo("C:\\databaseLsm");
            diskTablesMerger = Substitute.For<DiskTablesMerger>();
            memTable = Substitute.For<IMemTable>();

            method = MergeMethod.MergeByLevel;
            databaseManager = new DatabaseManager(memTable, diskTablesMerger, databaseDirectory, method);
        }

        [Test]
        public void Should_CallDiskTableMerger()
        {
            for (int i = 0; i < databaseManager.ItemsTreshold + 1; i++)
            {
                databaseManager.Add(Item.CreateItem(i.ToString(), i.ToString()));
            }

            switch (method)
            {
                case MergeMethod.MergeBySize:
                    diskTablesMerger.Received(1).MergeFilesBySize(databaseDirectory);
                    break;
                case MergeMethod.MergeByLevel:
                    diskTablesMerger.Received(1).MergeFilesByLevel(databaseDirectory);
                    break;
            }
            
        }
    }
}