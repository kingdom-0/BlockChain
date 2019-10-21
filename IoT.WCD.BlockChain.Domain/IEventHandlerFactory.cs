using System.Collections.Generic;

namespace IoT.WCD.BlockChain.Domain.DomainEvents
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : IEvent;
    }
}
