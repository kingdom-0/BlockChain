using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.DomainServices;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Application.CommandHandlers
{
    public class CreateECGDataCommandHandler : ICommandHandler<CreateECGDataCommand>
    {
        private readonly IECGDataService _ecgDataService;

        public CreateECGDataCommandHandler()
        {
             _ecgDataService = Ioc.Instance.Resolve<IECGDataService>();
        }

        public void Execute(CreateECGDataCommand createUserCommand)
        {
            if (createUserCommand == null)
            {
                throw new ArgumentNullException(nameof(createUserCommand));
            }

            _ecgDataService.Execute(createUserCommand);
        }
    }
}
