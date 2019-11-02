using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.DomainServices;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Application.CommandHandlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler()
        {
            _userService = Ioc.Instance.Resolve<IUserService>();
        }
        public void Execute(CreateUserCommand createUserCommand)
        {
            if (createUserCommand == null)
            {
                throw new ArgumentNullException(nameof(createUserCommand));
            }
            
            _userService.Execute(createUserCommand);
        }
    }
}
