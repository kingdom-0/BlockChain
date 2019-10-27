using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.DomainServices;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Application.CommandHandlers
{
    public class CreateAuthDataCommandHandler : ICommandHandler<CreateAuthorizationDataCommand>
    {
        private readonly IAuthDataService _authDataService;

        public CreateAuthDataCommandHandler()
        {
            _authDataService = IocContainer.Default.Resolve<IAuthDataService>();
        }

        public void Execute(CreateAuthorizationDataCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _authDataService.Execute(command);
        }
    }
}
