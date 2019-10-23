using IoT.WCD.BlockChain.Application.CommandHandlers;
using IoT.WCD.BlockChain.Application.Interfaces;
using IoT.WCD.BlockChain.Application.Services;
using IoT.WCD.BlockChain.Domain.DomainEvents;
using IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers;
using IoT.WCD.BlockChain.Domain.DomainServices;
using IoT.WCD.BlockChain.Domain.Queries;
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
        private static readonly UnityContainer Register = IocContainer.Default;

        public static void Configure()
        {
            Register.RegisterType<IEventStorage, InMemoryEventStorage>();
            Register.RegisterType<IUserRepository, UserRepository>();
            Register.RegisterType<ICommandBus, CommandBus>();
            Register.RegisterType<IEventBus, EventBus>();
            Register.RegisterType<IUserService, UserService>();
            Register.RegisterType<ICommandHandlerFactory, CommandHandlerFactory>();
            Register.RegisterType<IPersonalDataUploadService, PersonalDataUploadService>();
            Register.RegisterType<IUserDatabase, UserDatabase>();
            Register.RegisterType<IEventHandlerFactory, EventHandlerFactory>();
        }
    }
}
