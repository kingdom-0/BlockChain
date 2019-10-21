using System;

namespace IoT.WCD.BlockChain.Domain
{
    public interface IEvent
    {
        int Version { get; set; }
        Guid AggregateId { get; set; }
        Guid Id { get; }
    }
}
