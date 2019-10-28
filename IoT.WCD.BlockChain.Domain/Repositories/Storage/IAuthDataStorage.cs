using System;
using IoT.WCD.BlockChain.Domain.AggregateRoots;

namespace IoT.WCD.BlockChain.Domain.Repositories.Storage
{
    public interface IAuthDataStorage : IStorage<IAggregateRoot>
    {
        IAggregateRoot GetByUserId(Guid userId, string serviceKey);
    }
}
