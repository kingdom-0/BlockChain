using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.Entity;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
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
            var user = _userRepository.GetByPhoneNumber(createUserCommand.PhoneNumber);
            if (user != null)
            {
                throw new Exception("Phone number was registered.");
            }
            var newUser = new User(createUserCommand.Id,createUserCommand.Name,createUserCommand.PhoneNumber
                ,createUserCommand.Address,createUserCommand.GenderType)
            {
                Version = -1
            };
            _userRepository.Save(newUser,newUser.Version);
        }
    }
}
