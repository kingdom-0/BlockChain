using System;

namespace IoT.WCD.BlockChain.Repository.Mementos
{
    public class Memento
    {
        public Guid Id { get; internal set; }
        public int Version { get; set; }
    }
}
