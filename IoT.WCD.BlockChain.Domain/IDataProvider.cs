using System.Collections.Generic;

namespace IoT.WCD.BlockChain.Domain
{
    public interface IDataProvider
    {
        void LoadDataFromHistories(IEnumerable<IEvent> eventHistories);

        IEnumerable<IEvent> GetUncommittedChanges();
    }
}
