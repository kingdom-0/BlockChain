using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public class UserService : IUserService
    {

        public UserService()
        {
            
        }

        public void Execute(CreateUserCommand createUserCommand)
        {
            var userRepository = Ioc.Instance.Resolve<IUserRepository>();
            var user = userRepository.GetByPhoneNumber(createUserCommand.PhoneNumber);
            if (user != null)
            {
                throw new Exception("Phone number was registered.");
            }
            var newUser = new User(createUserCommand.Id,createUserCommand.Name,createUserCommand.PhoneNumber
                ,createUserCommand.Address,createUserCommand.GenderType)
            {
                Version = -1
            };
            userRepository.Save(newUser,newUser.Version);
        }
    }
}
