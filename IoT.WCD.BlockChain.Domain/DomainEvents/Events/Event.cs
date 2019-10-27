using System;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.Events
{
    public class Event:IEvent
    {
        public int Version { get;set; }
        public Guid AggregateId { get; set; }
        public Guid Id { get; set; }
    }
}
