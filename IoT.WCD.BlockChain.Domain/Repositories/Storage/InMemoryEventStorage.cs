using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.DomainEvents;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Repository.Storage
{
    public class InMemoryEventStorage : IEventStorage
    {
        private List<IEvent> _events;
        private List<Memento> _mementos;

        public InMemoryEventStorage()
        {
            _events = new List<IEvent>();
            _mementos = new List<Memento>();
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
                //if (version > 2)
                if(true)
                {
                    //if (version % 3 == 0)
                    if(true)
                    {
                        var originator = (IOriginator) aggregate;
                        var memento = originator.GetMemento();
                        memento.Version = version;
                        SaveMemento(memento);
                    }
                }

                uncommittedChange.Version = version;
                _events.Add(uncommittedChange);
            }

            var eventBus = Ioc.Instance.Resolve<IEventBus>();
            foreach (var uncommittedChange in uncommittedChanges)
            {
                dynamic targetEvent = Convert.ChangeType(uncommittedChange, uncommittedChange.GetType());
                eventBus.Publish(targetEvent);
            }
        }

        public T GetMemento<T>(Guid aggregateId) where T : Memento
        {
            var memento = _mementos.Where(m => m.Id == aggregateId).Select(m => m).LastOrDefault();
            return (T) memento;
        }

        public T GetMemento<T>(string searchKey) where T : Memento
        {
            var memento = _mementos.Where(m => m.SearchKey == searchKey).Select(m => m).LastOrDefault();
            return (T) memento;
        }

        public void SaveMemento(Memento memento)
        {
            _mementos.Add(memento);
        }
    }
}
