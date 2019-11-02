using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.DomainServices;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Application.CommandHandlers
{
    public class CreateAuthDataCommandHandler : ICommandHandler<CreateAuthorizationDataCommand>
    {
        public CreateAuthDataCommandHandler()
        {
            
        }

        public void Execute(CreateAuthorizationDataCommand command)
        {
            var authDataService = Ioc.Instance.Resolve<IAuthDataService>();
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            authDataService.Execute(command);
        }
    }
}
