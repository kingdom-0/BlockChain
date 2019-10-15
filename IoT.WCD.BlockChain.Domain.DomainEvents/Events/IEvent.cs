using System;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.Events
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}
