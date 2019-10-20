using IoT.WCD.BlockChain.Domain.Entity;
using IoT.WCD.BlockChain.Repository.Interfaces;
using IoT.WCD.BlockChain.Repository.Storage;

namespace IoT.WCD.BlockChain.Repository.Repositories
{
    public class UserRepository:BaseRepository<User>
    {
        public UserRepository(IEventStorage eventStorage) : base(eventStorage)
        {
        }
    }
}
