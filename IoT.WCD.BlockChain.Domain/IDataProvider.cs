using System.Collections.Generic;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;

namespace IoT.WCD.BlockChain.Domain
{
    public interface IDataProvider
    {
        void LoadDataFromHistories(IEnumerable<IEvent> eventHistories);

        IEnumerable<IEvent> GetUncommittedChanges();
    }
}
