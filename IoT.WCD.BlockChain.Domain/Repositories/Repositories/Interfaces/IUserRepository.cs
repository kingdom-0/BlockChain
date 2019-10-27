using IoT.WCD.BlockChain.Domain.AggregateRoots;

namespace IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        User GetByPhoneNumber(string phoneNumber);
    }
}
