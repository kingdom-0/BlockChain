using System.Threading.Tasks;

namespace IoT.WCD.BlockChain.Domain.DomainEvents
{
    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }
}
