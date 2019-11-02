using IoT.WCD.BlockChain.Application.CommandHandlers;
using IoT.WCD.BlockChain.Domain.DomainEvents;
using IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers;
using IoT.WCD.BlockChain.Domain.DomainServices;
using IoT.WCD.BlockChain.Domain.Queries;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Domain.Repositories.Storage;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using IoT.WCD.BlockChain.Messaging;
using IoT.WCD.BlockChain.Repository.Storage;

namespace IoT.WCD.BlockChain.BootStrapper
{
    public class Startup
    {
        private static bool _initialized;
        public static void Configure()
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;

            Ioc.Instance.RegisterType(typeof(ICommandBus),new CommandBus());
            Ioc.Instance.RegisterType(typeof(IEventBus),new EventBus());

            //Readonly
            Ioc.Instance.RegisterType(typeof(IUserDatabase),new UserDatabase());
            Ioc.Instance.RegisterType(typeof(IECGDataDatabase),new ECGDataDatabase());
            Ioc.Instance.RegisterType(typeof(IAuthDataDatabase),new AuthDataDatabase());

            //Writable
            Ioc.Instance.RegisterType(typeof(ICommandHandlerFactory),new CommandHandlerFactory());


            Ioc.Instance.RegisterType(typeof(IECGDataService), new ECGDataService());
            Ioc.Instance.RegisterType(typeof(IUserService),new UserService());

            Ioc.Instance.RegisterType(typeof(IAuthDataService), new AuthDataService());
            
            Ioc.Instance.RegisterType(typeof(IUserRepository), new UserRepository());
            Ioc.Instance.RegisterType(typeof(IECGDataRepository), new ECGDataRepoistory());
            Ioc.Instance.RegisterType(typeof(IAuthDataRepository), new AuthDataRepository());
            
            Ioc.Instance.RegisterType(typeof(IEventStorage),new InMemoryEventStorage());
            Ioc.Instance.RegisterType(typeof(IAuthDataStorage),new InMemoryAuthDataStorage());
            Ioc.Instance.RegisterType(typeof(IAuthDataDatabase),new AuthDataDatabase());

            Ioc.Instance.RegisterType(typeof(IEventHandlerFactory),new EventHandlerFactory());
        }
    }
}
