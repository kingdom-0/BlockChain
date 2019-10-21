﻿using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainEvents
{
    public class EventBus : IEventBus
    {
        public EventBus()
        {
            
        }
        public void Publish<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            var eventHandlerFactory = IocContainer.Default.Resolve<IEventHandlerFactory>();
            var handlers = eventHandlerFactory.GetHandlers<TEvent>();
            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}