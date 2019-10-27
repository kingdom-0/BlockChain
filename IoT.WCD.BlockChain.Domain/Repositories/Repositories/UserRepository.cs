using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;

namespace IoT.WCD.BlockChain.Domain.Repositories.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User GetByPhoneNumber(string phoneNumber)
        {
            return GetBySearchKey(phoneNumber);
        }
    }
}
