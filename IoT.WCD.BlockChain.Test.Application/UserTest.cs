using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.BootStrapper;
using IoT.WCD.BlockChain.Domain.Queries;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using IoT.WCD.BlockChain.Messaging;
using IoT.WCD.BlockChain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IoT.WCD.BlockChain.Test.Application
{
    [TestClass]
    public class UserTest
    {
        private static Guid _userId;

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
                GenderType = GenderType.Female,
                Address = "人民路8号",
                Version = -1
            };
            var createUserCommand = new CreateUserCommand(user.Id, user.Name,user.PhoneNumber,user.GenderType,user.Address,user.Version);
            var commandBus = Ioc.Instance.Resolve<ICommandBus>();
            commandBus.Send(createUserCommand);
            _userId = user.Id;
            var userDb = Ioc.Instance.Resolve<IUserDatabase>();
            var userInstance = userDb.GetById(_userId);
            Assert.IsNotNull(userInstance);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            var userDb = Ioc.Instance.Resolve<IUserDatabase>();
            var user = userDb.GetById(_userId);
            Assert.IsTrue(user != null);
        }

        [TestMethod]
        public void GetUsersTest()
        {
            var userDb = Ioc.Instance.Resolve<IUserDatabase>();
            var items = userDb.GetItems();
            Assert.IsTrue(items.Count==1);
        }
    }
}
