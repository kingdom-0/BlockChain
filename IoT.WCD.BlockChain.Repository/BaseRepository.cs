﻿using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain.Common;
using IoT.WCD.BlockChain.Repository.Interfaces;
using IoT.WCD.BlockChain.Repository.Mementos;
using IoT.WCD.BlockChain.Repository.Storage;

namespace IoT.WCD.BlockChain.Repository
{
    public abstract class BaseRepository<TAggregateRoot>:IRepository<TAggregateRoot>
        where TAggregateRoot:class,IAggregateRoot,new()
    {
        private readonly IEventStorage _eventStorage;
        private static readonly object Locker = new object();
        //protected readonly IQueryable<TAggregateRoot> _entities;

        public BaseRepository(IEventStorage eventStorage)
        {
            _eventStorage = eventStorage;
        }

        public TAggregateRoot GetById(Guid id)
        {
            IEnumerable<IEvent> events;
            var memento = _eventStorage.GetMemento<Memento>(id);
            if (memento != null)
            {
                events = _eventStorage.GetEvents(id).Where(e => e.Version >= memento.Version);
            }
            else
            {
                events = _eventStorage.GetEvents(id);
            }

            var instance = new TAggregateRoot();
            if (memento != null)
            {
                ((IOriginator)instance).SetMemento(memento);
            }
            
            instance.LoadDataFromHistories(events);
            return instance;
        }

        public void Save(IAggregateRoot aggregateRoot, int expectedVersion)
        {
            if (!aggregateRoot.GetUncommittedChanges().Any())
            {
                return;
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

                _eventStorage.Save(entity);
            }
        }
    }
}
