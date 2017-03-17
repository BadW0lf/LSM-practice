using System;
using DataLayer;
using DataLayer.DataModel;
using DataLayer.MemoryCopy;
using DataLayer.Utilities;
using DataLayer.Warmup;
using FluentAssertions;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    public class OpLogApplierTests
    {
        private string filePath;

        [SetUp]
        public void SetUp()
        {
            filePath = Guid.NewGuid().ToString();
        }

        [TearDown]
        public void TearDown()
        {
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        [Test]
        public void Should_apply_operation_from_opLog()
        {
            var opLogManager = new OpLogManager(new File(filePath), new OperationSerializer());
            var olApplier = new OpLogApplier(opLogManager);
            var initialMemTable = new MemTable(opLogManager);

            var item1 = Item.CreateItem(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            var item2 = Item.CreateItem(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            initialMemTable.Add(item1);
            initialMemTable.Add(item2);

            var newMemTable = new MemTable(opLogManager);

            olApplier.Apply(newMemTable);

            var itemFromTable1 = newMemTable.Get(item1.Key);
            var itemFromTable2 = newMemTable.Get(item2.Key);

            itemFromTable1.Should().Be(item1);
            itemFromTable2.Should().Be(item2);
        }
    }
}
