using System;
using IoT.WCD.BlockChain.Application.CommandHandlers;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.BootStrapper;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace IoT.WCD.BlockChain.Test.Application
{
    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public void Setup()
        {
            Startup.Configure();
        }

        [TestMethod]
        public void TestCreateUserCommand()
        {
            CreateUserCommand createUserCommand = new CreateUserCommand(Guid.NewGuid(), "admin","14514214579",GenderType.Male,"人民路8号",-1);
            var handlerFactory = IocContainer.Default.Resolve<ICommandHandlerFactory>();
            var createUserCommandHandler = handlerFactory.GetHandler<CreateUserCommand>();
            createUserCommandHandler.Execute(createUserCommand);

        }
    }
}
