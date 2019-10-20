using System;
using IoT.WCD.BlockChain.Domain.Common;

namespace IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot:class,IAggregateRoot
    {
        TAggregateRoot GetById(Guid id);

        TAggregateRoot GetBySearchKey(string searchKey);

        void Save(IAggregateRoot aggregateRoot, int expectedVersion);
    }
}
