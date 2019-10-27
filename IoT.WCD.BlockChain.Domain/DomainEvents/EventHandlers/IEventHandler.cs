using IoT.WCD.BlockChain.Domain.DomainEvents.Events;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers
{
    public interface IEventHandler<in TEvent>
        where TEvent : Event
    {
        void Handle(TEvent @event);
    }
}
