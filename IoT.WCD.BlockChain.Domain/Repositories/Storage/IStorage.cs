using IoT.WCD.BlockChain.Domain.AggregateRoots;

namespace IoT.WCD.BlockChain.Domain.Repositories.Storage
{
    public interface IStorage<T> where T : IAggregateRoot
    {
        void Save(T aggregate);
    }
}
