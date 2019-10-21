using System;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.Events
{
    [Serializable]
    public class Event:IEvent
    {
        public int Version { get;set; }
        public Guid AggregateId { get; set; }
        public Guid Id { get; private set; }
    }
}
