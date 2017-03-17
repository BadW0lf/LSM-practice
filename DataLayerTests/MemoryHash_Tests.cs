using System;
using DataLayer;
using DataLayer.DataModel;
using DataLayer.MemoryCopy;
using DataLayer.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    public class MemTableTests
    {
        private MemTable memTable;
        private string filePath;

        [SetUp]
        public void SetUp()
        {
            filePath = Guid.NewGuid().ToString();
            memTable = new MemTable(new OpLogManager(new File(filePath), new OperationSerializer()));
        }

        [TearDown]
        public void TearDown()
        {
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        [Test]
        public void Should_add_items()
        {
            var item1 = Item.CreateItem(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            var item2 = Item.CreateItem(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            memTable.Add(item1);
            memTable.Add(item2);

            var itemFromTable1 = memTable.Get(item1.Key);
            var itemFromTable2 = memTable.Get(item2.Key);

            itemFromTable1.Should().Be(item1);
            itemFromTable2.Should().Be(item2);
        }

        [Test]
        public void Should_overwrite_item_with_same_key()
        {
            var key = Guid.NewGuid().ToString();

            var item = Item.CreateItem(key, Guid.NewGuid().ToString());
            var tombstone = Item.CreateTombStone(key);

            memTable.Add(item);
            memTable.Add(tombstone);

            var itemFromTable = memTable.Get(key);

            itemFromTable.Should().Be(tombstone);
        }
    }
}
