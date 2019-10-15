﻿namespace IoT.WCD.BlockChain.Domain.DomainEvents.Events
{
    public interface IHandle<TEvent> where TEvent:Event
    {
        void Handle(TEvent e);
    }
}
