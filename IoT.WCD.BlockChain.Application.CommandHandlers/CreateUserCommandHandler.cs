using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.DomainServices;


namespace IoT.WCD.BlockChain.Application.CommandHandlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        //private IRepository<User> _repository;
        private IUserService _userService;

        public CreateUserCommandHandler()
        {
            
        }

        public void Execute(CreateUserCommand command)
        {
            //TODO:
            if (command.Id != null)
            {

            }
        }
    }
}
