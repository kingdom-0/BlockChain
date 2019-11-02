using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using IoT.WCD.BlockChain.Repository.Mementos;
using IoT.WCD.BlockChain.Repository.Storage;
using Unity;

namespace IoT.WCD.BlockChain.Domain.Repositories
{
    public abstract class BaseRepository<TAggregateRoot>:IRepository<TAggregateRoot>
        where TAggregateRoot:class,IAggregateRoot,new()
    {
        private static readonly object Locker = new object();

        protected BaseRepository()
        {
            
        }

        public virtual TAggregateRoot GetById(Guid id)
        {
            var eventStorage = Ioc.Instance.Resolve<IEventStorage>();
            var memento = eventStorage.GetMemento<Memento>(id);
            if (memento == null)
            {
                return default(TAggregateRoot);
            }
            return GetBySpecCondition(memento);
        }

        public virtual TAggregateRoot GetBySearchKey(string searchKey)
        {
            var eventStorage = Ioc.Instance.Resolve<IEventStorage>();
            var memento = eventStorage.GetMemento<Memento>(searchKey);
            if (memento == null)
            {
                return default(TAggregateRoot);
            }
            return GetBySpecCondition(memento);
        }

        private TAggregateRoot GetBySpecCondition(Memento memento)
        {
            var eventStorage = Ioc.Instance.Resolve<IEventStorage>();
            IEnumerable<IEvent> events;
            if (memento != null)
            {
                events = eventStorage.GetEvents(memento.Id).Where(e => e.Version >= memento.Version);
            }
            else
            {
                events = eventStorage.GetEvents(memento.Id);
            }

            var instance = new TAggregateRoot();
            if (memento != null)
            {
                ((IOriginator)instance).SetMemento(memento);
            }
            
            instance.LoadDataFromHistories(events);
            return instance;
        }

        public virtual void Save(IAggregateRoot aggregateRoot, int expectedVersion)
        {
            var eventStorage = Ioc.Instance.Resolve<IEventStorage>();
            if (!aggregateRoot.GetUncommittedChanges().Any())
            {
                //TODO: In order to debug, save single aggregate instance.
                //return;
            }

            lock (Locker)
            {
                var entity = new TAggregateRoot();
                if (expectedVersion != -1)
                {
                    entity = GetById(aggregateRoot.Id);
                }

                if (entity.Version != expectedVersion)
                {
                    throw new Exception($"Entity {aggregateRoot} has been modified previously");
                }

                eventStorage.Save(aggregateRoot);
            }
        }
    }
}
