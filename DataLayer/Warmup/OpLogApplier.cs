using DataLayer.MemoryCopy;

namespace DataLayer.Warmup
{
    public class OpLogApplier : IOpLogApplier
    {
        private readonly IOpLogReader opLogReader;

        public OpLogApplier(IOpLogReader opLogReader)
        {
            this.opLogReader = opLogReader;
        }

        public void Apply(IMemTable memTable)
        {
            throw new System.NotImplementedException();
        }
    }
}