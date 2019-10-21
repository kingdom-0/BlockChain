namespace IoT.WCD.BlockChain.Domain.DomainEvents
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }
}
