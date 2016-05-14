using System;
using DataLayer;
using FluentAssertions;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    public class OperationLogTests_part1
    {
        private IOperationLog operationLog;

        [SetUp]
        public void SetUp()
        {
            IFileSystem fs = NSubstitute.Substitute.For<IFileSystem>();
            operationLog = new OperationLog(fs);
        }

        [Test]
        public void Should_add_operations_to_internal_list()
        {
            operationLog.Add(new Operation {Id = Guid.NewGuid(), StoredItem = new Item {Name = "item1", Value = "1"}});

            operationLog.Read(0, 1).Should().HaveCount(1);
        }

        [Test]
        public void Should_work_fine_with_big_number_of_writes()
        {
            Action action = () =>
            {

                for (int i = 0; i < 200; i++)
                {
                    operationLog.Add(new Operation());
                }
            };

            action.ShouldNotThrow<OutOfMemoryException>();
        }
    }
}
