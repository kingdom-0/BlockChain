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
    public class ECGDataTest
    {
        [TestInitialize]
        public void Setup()
        {
            Startup.Configure();
        }

        [TestMethod]
        public void AddEcgDataTest()
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
            var commandBus = IocContainer.Default.Resolve<ICommandBus>();
            commandBus.Send(createUserCommand);
            var userDb = IocContainer.Default.Resolve<IUserDatabase>();
            var userDto = userDb.GetById(user.Id);

            var ecgDataId = Guid.NewGuid();
            var createEcgDataCommand = new CreateECGDataCommand(user.Id,new byte[]{0x0,0x1,0x2},
                new byte[]{0x3,0x4,0x5},DateTime.Now, ecgDataId, -1);
            commandBus.Send(createEcgDataCommand);
            var ecgDataDb = IocContainer.Default.Resolve<IECGDataDatabase>();
            var ecgDatDtoList = ecgDataDb.GetECGDataByUserId(user.Id);
            var ecgDataDto = ecgDataDb.GetById(ecgDataId);

            var authDataDto = new AuthDataDto
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                AuthorizationType = AuthorizationType.ReadAndWrite,
                ServiceKey = Guid.NewGuid().ToString(),
                CreateTime = DateTime.Now
            };

            var createAuthDataCommand = new CreateAuthorizationDataCommand(authDataDto.Id, authDataDto.UserId,
                authDataDto.ServiceKey, authDataDto.AuthorizationType, authDataDto.Version);
            commandBus.Send(createAuthDataCommand);
            var authDataDb = IocContainer.Default.Resolve<IAuthDataDatabase>();
            var authDataDto1 = authDataDb.GetById(createAuthDataCommand.Id);

        }
    }
}
