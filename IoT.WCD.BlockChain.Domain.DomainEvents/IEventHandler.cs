using System.Threading.Tasks;

namespace IoT.WCD.BlockChain.Domain.DomainEvents
{
    public interface IEventHandler<in TEvent>
        where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}
