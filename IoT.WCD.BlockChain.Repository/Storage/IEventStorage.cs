﻿using System;
using System.Collections.Generic;
using IoT.WCD.BlockChain.Domain.Common;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Repository.Storage
{
    public interface IEventStorage
    {
        IEnumerable<IEvent> GetEvents(Guid aggregateId);
        void Save(IAggregateRoot aggregate);
        T GetMemento<T>(Guid aggregateId) where T: Memento;
        void SaveMemento(Memento memento);
    }
}
