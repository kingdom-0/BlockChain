using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.BootStrapper;
using IoT.WCD.BlockChain.Domain.Queries;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using IoT.WCD.BlockChain.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace IoT.WCD.BlockChain.Test.Application
{
    [TestClass]
    public class UserTest
    {
        private Guid _userId;

        [TestInitialize]
        public void Setup()
        {
            Startup.Configure();
        }

        [TestMethod]
        public void CreateUserCommandTest()
        {
            var user = new UserDto
            {
                Id = Guid.NewGuid(),
                Name = "admin",
                PhoneNumber = "18021578599",
                GenerType = GenderType.Female,
                Address = "人民路8号",
                Version = -1
            };
            var createUserCommand = new CreateUserCommand(user.Id, user.Name,user.PhoneNumber,user.GenerType,user.Address,user.Version);
            var commandBus = IocContainer.Default.Resolve<ICommandBus>();
            commandBus.Send(createUserCommand);
            _userId = user.Id;
            var userDb = IocContainer.Default.Resolve<IUserDatabase>();
            var userById = userDb.GetById(_userId);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            var userDb = IocContainer.Default.Resolve<IUserDatabase>();
            var user = userDb.GetById(_userId);
            Assert.IsTrue(user != null);
        }

        [TestMethod]
        public void GetUsersTest()
        {
            var userDb = IocContainer.Default.Resolve<IUserDatabase>();
            var items = userDb.GetItems();
            Assert.IsTrue(items.Count==1);
        }
    }
}
