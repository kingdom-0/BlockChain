using System;
using System.Collections.Generic;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;

namespace IoT.WCD.BlockChain.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }

        int Version { get; set; }

        void LoadDataFromHistories(IEnumerable<IEvent> eventHistories);

        IEnumerable<IEvent> GetUncommittedChanges();
    }
}
