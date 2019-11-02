using System;
using System.Linq;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.BootStrapper;
using IoT.WCD.BlockChain.Domain.Queries;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Infrastructure.Exceptions;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using IoT.WCD.BlockChain.Infrastructure.Utilities;
using IoT.WCD.BlockChain.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace IoT.WCD.BlockChain.Test.Application
{
    [TestClass]
    public class ECGDataTest
    {
        private static Guid _userId;
        private static string _accessToken;
        private const string ServiceKey = "ServiceKeyForTest";

        [TestInitialize]
        public void Initialize()
        {
            Startup.Configure();
        }

        [TestMethod]
        public void AddUserTest()
        {
            var user = new UserDto
            {
                Id = Guid.NewGuid(),
                Name = "admin",
                PhoneNumber = "18021578599",
                GenerType = GenderType.Female,
                Address = "Suzhou,SIP.",
                Version = -1
            };
            var createUserCommand = new CreateUserCommand(user.Id, user.Name,user.PhoneNumber,user.GenerType,user.Address,user.Version);
            var commandBus = Ioc.Instance.Resolve<ICommandBus>();
            commandBus.Send(createUserCommand);
            var userDb = Ioc.Instance.Resolve<IUserDatabase>();
            var userDto = userDb.GetById(user.Id);
            Assert.IsNotNull(userDto);
            _userId = userDto.Id;
        }

        [TestMethod]
        public void AddAuthDataTest()
        {
            var commandBus = Ioc.Instance.Resolve<ICommandBus>();
            var authDataDto = new AuthDataDto
            {
                Id = Guid.NewGuid(),
                UserId = _userId,
                AuthorizationType = AuthorizationType.ReadAndWrite,
                ServiceKey = ServiceKey,
                CreateTime = DateTime.Now
            };

            var createAuthDataCommand = new CreateAuthorizationDataCommand(authDataDto.Id, authDataDto.UserId,
                authDataDto.ServiceKey, authDataDto.AuthorizationType, authDataDto.Version);
            commandBus.Send(createAuthDataCommand);
            var authDataDb = Ioc.Instance.Resolve<IAuthDataDatabase>();
            var authDataDtoInstance = authDataDb.GetById(createAuthDataCommand.Id);
            Assert.IsNotNull(authDataDtoInstance);
        }

        [TestMethod]
        public void AddEcgDataTest()
        {
            var commandBus = Ioc.Instance.Resolve<ICommandBus>();
            var ecgDataId = Guid.NewGuid();
            var createEcgDataCommand = new CreateECGDataCommand(_userId,new byte[]{0x0,0x1,0x2},
                new byte[]{0x3,0x4,0x5},DateTime.Now, ecgDataId, -1);
            commandBus.Send(createEcgDataCommand);
            var ecgDataDb = Ioc.Instance.Resolve<IECGDataDatabase>();
            var ecgDataDto = ecgDataDb.GetById(ecgDataId);//TODO:get data must with service key
            Assert.IsNull(ecgDataDto);
        }

        [TestMethod]
        public void RetrieveEcgDataWithValidServiceKeyTest()
        {
            var ecgDataDb = Ioc.Instance.Resolve<IECGDataDatabase>();
            var ecgDatDtoResult = ecgDataDb.GetUserECGDataByServiceKey(_userId, ServiceKey);
            Assert.AreEqual(ecgDatDtoResult.Result,true);
        }

        [TestMethod]
        public void RetrieveEcgDataWithInvalidServiceKeyTest()
        {
            var ecgDataDb = Ioc.Instance.Resolve<IECGDataDatabase>();
            var ecgDatDtoResult = ecgDataDb.GetUserECGDataByServiceKey(_userId, string.Empty);
            Assert.AreNotEqual(ecgDatDtoResult.Result,true);
        }

        [TestMethod]
        public void RetrieveEcgDataWithValidTokenTest()
        {
            var ecgDataDb = Ioc.Instance.Resolve<IECGDataDatabase>();
            var userRepository = Ioc.Instance.Resolve<IUserRepository>();
            var user = userRepository.GetById(_userId);
            _accessToken = user.GetUserKey().GetReverseData();
            var ecgDataList = ecgDataDb.GetUserEcgDataByToken(_userId, _accessToken);
            Assert.IsTrue(ecgDataList.Count >= 0);
        }

        [TestMethod]
        public void RetrieveEcgDataWithInvalidTokenTest()
        {
            var ecgDataDb = Ioc.Instance.Resolve<IECGDataDatabase>();
            var userRepository = Ioc.Instance.Resolve<IUserRepository>();
            var user = userRepository.GetById(_userId);
            Assert.ThrowsException<InvalidAccessException>(() =>
            {
                ecgDataDb.GetUserEcgDataByToken(_userId, user.GetUserKey());
            });
            
        }
    }
}
