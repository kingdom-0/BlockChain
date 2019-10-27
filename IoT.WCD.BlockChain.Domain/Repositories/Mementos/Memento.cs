using System;

namespace IoT.WCD.BlockChain.Repository.Mementos
{
    public class Memento
    {
        public Guid Id { get; internal set; }
        public string SearchKey{get; set; }
        public int Version { get; set; }

        public int EventVersion { get; internal set; }
    }
}
