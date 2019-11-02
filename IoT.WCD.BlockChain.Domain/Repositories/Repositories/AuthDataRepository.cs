using System;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Domain.Repositories.Storage;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.Repositories.Repositories
{
    public class AuthDataRepository : BaseRepository<AuthorizationData>, IAuthDataRepository
    {

        public AuthDataRepository()
        {
            
        }

        public override void Save(IAggregateRoot aggregateRoot, int expectedVersion)
        {
            base.Save(aggregateRoot, expectedVersion);
            var authDataStorage = Ioc.Instance.Resolve<IAuthDataStorage>();
            authDataStorage.Save(aggregateRoot);
        }

        public override AuthorizationData GetById(Guid id)
        {
            return base.GetById(id);
        }

        public override AuthorizationData GetBySearchKey(string searchKey)
        {
            return base.GetBySearchKey(searchKey);
        }
    }
}
