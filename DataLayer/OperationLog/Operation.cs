using System;

namespace DataLayer
{
    public struct Operation
    {
        public Guid Id { get; set; }

        public Item StoredItem { get; set; }
    }
}