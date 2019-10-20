using System.Collections.Generic;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;

namespace IoT.WCD.BlockChain.Domain.DomainEvents
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : IEvent;
    }
}
