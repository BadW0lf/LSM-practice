using System;
using DataLayer;
using DataLayer.MemoryHash;
using FluentAssertions;
using NSubstitute;
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

            var memoryHash = new MemoryCopy(operationLog);
       
            memoryHash.Get(expectedGuid).Should().Be(storedItem);
        }

        [Test]
        public void ShouldStoreOperationsDirectlyOnOPerationLog()
        {
            var fs = NSubstitute.Substitute.For<IFileSystem>();
            var operationLog = NSubstitute.Substitute.For<IOperationLog>();
            var memoryHash = new MemoryCopy(operationLog);

            memoryHash.Add(Guid.NewGuid(), new Item(){Name = "1", Value = "1"});

            operationLog.Received(1).Add(Arg.Any<Operation>());
        }
    }
}