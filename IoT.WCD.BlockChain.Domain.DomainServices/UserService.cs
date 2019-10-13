using IoT.WCD.BlockChain.Infrastructure;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;

        //private static readonly IRepostory<User>

        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add()
        {

        }
    }
}
