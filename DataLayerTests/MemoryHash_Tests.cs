using System;
using DataLayer;
using DataLayer.MemoryHash;
using FluentAssertions;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    public class MemoryHash_Tests
    {
        [Test]
        public void ShouldRestoreFromDisk()
        {
            var fs = NSubstitute.Substitute.For<IFileSystem>();
            var operationLog = new OperationLog(fs);
            var expectedGuid = Guid.NewGuid();
            var storedItem = new Item {Name = "1", Value = "2"};
            operationLog.Add(new Operation {Id = expectedGuid, StoredItem = storedItem});

            var memoryHash = new MemoryHash(operationLog);
       
            memoryHash.Get(expectedGuid).Should().Be(storedItem);
        }
    }
}