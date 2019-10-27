using System;
using System.Collections.Generic;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Repositories.Storage;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Repository.Storage
{
    public interface IEventStorage : IStorage<IAggregateRoot>
    {
        IEnumerable<IEvent> GetEvents(Guid aggregateId);
        T GetMemento<T>(Guid aggregateId) where T : Memento;
        T GetMemento<T>(string searchKey) where T : Memento;
        void SaveMemento(Memento memento);
    }
}
