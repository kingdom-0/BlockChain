﻿using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain.Common;
using IoT.WCD.BlockChain.Domain.DomainEvents;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Repository.Storage
{
    public class InMemoryEventStorage:IEventStorage
    {
        private List<IEvent> _events;
        private List<Memento> _mementos;
        private readonly IEventBus _eventBus;

        public InMemoryEventStorage(IEventBus eventBus)
        {
            _events = new List<IEvent>();
            _mementos = new List<Memento>();
            _eventBus = eventBus;
        }

        public IEnumerable<IEvent> GetEvents(Guid aggregateId)
        {
            var events = _events.Where(e => e.AggregateId == aggregateId).Select(e => e);
            if (!events.Any())
            {
                throw new Exception($"Aggregate with id {aggregateId} was not found");
            }

            return events;
        }

        public void Save(IAggregateRoot aggregate)
        {
            var uncommittedChanges = aggregate.GetUncommittedChanges();
            var version = aggregate.Version;

            foreach (var uncommittedChange in uncommittedChanges)
            {
                version++;
                if (version > 2)
                {
                    if (version % 3 == 0)
                    {
                        var originator = (IOriginator)aggregate;
                        var memento = originator.GetMemento();
                        memento.Version = version;
                        SaveMemento(memento);
                    }
                }

                uncommittedChange.Version = version;
                _events.Add(uncommittedChange);
            }

            foreach (var uncommittedChange in uncommittedChanges)
            {
                dynamic targetEvent = Convert.ChangeType(uncommittedChange, uncommittedChange.GetType());
                _eventBus.Publish(targetEvent);
            }
        }

        public T GetMemento<T>(Guid aggregateId) where T : Memento
        {
            throw new NotImplementedException();
        }

        public void SaveMemento(Memento memento)
        {
            throw new NotImplementedException();
        }
    }
}
