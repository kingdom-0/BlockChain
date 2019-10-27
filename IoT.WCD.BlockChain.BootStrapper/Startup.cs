﻿using IoT.WCD.BlockChain.Application.CommandHandlers;
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
using Unity;

namespace IoT.WCD.BlockChain.BootStrapper
{
    public class Startup
    {
        private static readonly UnityContainer Register = IocContainer.Default;

        public static void Configure()
        {
            Register.RegisterType<ICommandBus, CommandBus>();
            Register.RegisterType<IEventBus, EventBus>();

            //ReadOnly
            Register.RegisterType<IUserDatabase, UserDatabase>();
            Register.RegisterType<IECGDataDatabase, ECGDataDatabase>();
            Register.RegisterType<IECGDataDatabaseProxy, ECGDataDatabaseProxy>();
            Register.RegisterType<IAuthDataDatabase, AuthDataDatabase>();

            //Writable
            Register.RegisterType<ICommandHandlerFactory, CommandHandlerFactory>();

            Register.RegisterType<IECGDataService, ECGDataService>();
            Register.RegisterType<IUserService, UserService>();
            Register.RegisterType<IAuthDataService, AuthDataService>();
            
            Register.RegisterType<IUserRepository, UserRepository>();
            Register.RegisterType<IECGDataRepository, ECGDataRepoistory>();
            Register.RegisterType<IAuthDataRepository, AuthDataRepository>();
            
            Register.RegisterType<IEventStorage, InMemoryEventStorage>();
            Register.RegisterType<IAuthDataStorage, InMemoryAuthDataStorage>();

            Register.RegisterType<IEventHandlerFactory, EventHandlerFactory>();
        }
    }
}
