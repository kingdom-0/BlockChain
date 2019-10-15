using IoT.WCD.BlockChain.Application.CommandHandlers;
using IoT.WCD.BlockChain.Application.Interfaces;
using IoT.WCD.BlockChain.Application.Services;
using IoT.WCD.BlockChain.Domain.DomainEvents;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using IoT.WCD.BlockChain.Messaging;
using Unity;

namespace IoT.WCD.BlockChain.BootStrapper
{
    public class Startup
    {
        private static readonly UnityContainer _register = IocContainer.Default;

        public static void Configure()
        {
            _register.RegisterType<ICommandBus, CommandBus>();
            _register.RegisterType<IEventBus, EventBus>();
            _register.RegisterType<ICommandHandlerFactory, CommandHandlerFactory>();
            _register.RegisterType<IPersonalDataUploadService, PersonalDataUploadService>();
        }
    }
}
