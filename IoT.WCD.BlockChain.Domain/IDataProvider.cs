using System.Collections.Generic;
using IoT.WCD.BlockChain.Domain.Common;

namespace IoT.WCD.BlockChain.Domain
{
    public interface IDataProvider
    {
        void LoadDataFromHistories(IEnumerable<IEvent> eventHistories);

        IEnumerable<IEvent> GetUncommittedChanges();
    }
}
