﻿namespace IoT.WCD.BlockChain.Domain.DomainEvents
{
    public interface IEventHandler<in TEvent>
        where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
