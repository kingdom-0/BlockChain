using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.DomainServices;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Application.CommandHandlers
{
    public class CreateECGDataCommandHandler : ICommandHandler<CreateECGDataCommand>
    {
        private readonly IECGDataService _ecgDataService;
        //private readonly ICommandHandler<ChangeUserActiveTimeCommand>

        public CreateECGDataCommandHandler()
        {
             _ecgDataService = Ioc.Instance.Resolve<IECGDataService>();
        }

        public void Execute(CreateECGDataCommand createEcgCommand)
        {
            if (createEcgCommand == null)
            {
                throw new ArgumentNullException(nameof(createEcgCommand));
            }

            _ecgDataService.Execute(createEcgCommand);

            var commandFactory = Ioc.Instance.Resolve<ICommandHandlerFactory>();
            var userRepository = Ioc.Instance.Resolve<IUserRepository>();
            var newUserVersion = userRepository.GetById(createEcgCommand.UserId).Version;
            var changeUserActiveTimeCommand =
                new ChangeUserActiveTimeCommand(Guid.NewGuid(), createEcgCommand.UserId, newUserVersion, DateTime.Now);
            var changeUserActiveTimeCommandHandler =
                commandFactory.GetHandler<ChangeUserActiveTimeCommand>();
            changeUserActiveTimeCommandHandler.Execute(changeUserActiveTimeCommand);
        }
    }
}
