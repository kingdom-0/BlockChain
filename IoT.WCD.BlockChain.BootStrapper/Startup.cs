using IoT.WCD.BlockChain.Application.CommandHandlers;
using IoT.WCD.BlockChain.Application.Interfaces;
using IoT.WCD.BlockChain.Application.Services;
using IoT.WCD.BlockChain.Domain.DomainEvents;
using IoT.WCD.BlockChain.Domain.DomainServices;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using IoT.WCD.BlockChain.Messaging;
using IoT.WCD.BlockChain.Repository.Storage;
using Unity;

namespace IoT.WCD.BlockChain.BootStrapper
{
    public class Startup
    {
        private static readonly UnityContainer _register = IocContainer.Default;

        public static void Configure()
        {
            //_register.RegisterType<IEventHandlerFactory, Eventhan>()
            _register.RegisterType<IEventStorage, InMemoryEventStorage>();
            _register.RegisterType<IUserRepository, UserRepository>();
            _register.RegisterType<ICommandBus, CommandBus>();
            _register.RegisterType<IEventBus, EventBus>();
            _register.RegisterType<IUserService, UserService>();
            _register.RegisterType<ICommandHandlerFactory, CommandHandlerFactory>();
            _register.RegisterType<IPersonalDataUploadService, PersonalDataUploadService>();
        }
    }
}
