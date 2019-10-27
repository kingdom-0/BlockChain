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
        private readonly IAuthDataStorage _authDataStorage;

        public AuthDataRepository()
        {
            _authDataStorage = IocContainer.Default.Resolve<IAuthDataStorage>();
        }

        public override void Save(IAggregateRoot aggregateRoot, int expectedVersion)
        {
            base.Save(aggregateRoot, expectedVersion);
            _authDataStorage.Save(aggregateRoot);
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
