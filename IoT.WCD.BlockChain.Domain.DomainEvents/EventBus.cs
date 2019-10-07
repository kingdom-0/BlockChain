using System.Threading.Tasks;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainEvents
{
    public class EventBus : IEventBus
    {
        public async Task Publish<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            var eventHandler = IocContainer.Default.Resolve<IEventHandler<TEvent>>();
            await eventHandler.Handle(@event);
        }
    }
}
