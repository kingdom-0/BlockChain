using System.Collections.Generic;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers
{
    public interface IEventHandlerFactory
    {
        List<IEventHandler<T>> GetHandlers<T>() where T : IEvent;
    }
}
