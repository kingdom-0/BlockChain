using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using IoT.WCD.BlockChain.Repository.Interfaces;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = IocContainer.Default.Resolve<IUserRepository>();
        }
        public void Execute(CreateUserCommand createUserCommand)
        {
            //var user = _userRepository.
        }
    }
}
