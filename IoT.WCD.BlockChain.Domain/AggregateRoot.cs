using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Infrastructure.Utilities;

namespace IoT.WCD.BlockChain.Domain
{
    public class AggregateRoot : IAggregateRoot,IDataProvider
    {
        private readonly List<IEvent> _changeEvents;

        public Guid Id { get; protected set; }
        public int Version { get; set; }
        public int EventVersion { get; internal set; }

        protected AggregateRoot()
        {
            Version = -1;
            Id = Guid.NewGuid();
            _changeEvents = new List<IEvent>();
        }

        protected AggregateRoot(Guid guid)
        {
            Version = -1;
            Id = guid;
            _changeEvents = new List<IEvent>();
        }

        public void LoadDataFromHistories(IEnumerable<IEvent> eventHistories)
        {
            foreach (var eventHistory in eventHistories)
            {
                ApplyChange(eventHistory,false);
            }

            Version = eventHistories.Last().Version;
            EventVersion = Version;
        }

        public IEnumerable<IEvent> GetUncommittedChanges()
        {
            return _changeEvents;
        }

        protected void ApplyChange(IEvent changeEvent)
        {
            ApplyChange(changeEvent,true);
        }

        private void ApplyChange(IEvent changEvent, bool isNew)
        {
            dynamic d = this;
            var destEvent = Converter.ChangeTo(changEvent, changEvent.GetType());
            d.Handle(destEvent);
            if (isNew)
            {
                _changeEvents.Add(changEvent);
            }
        }
    }
}
