using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.Entity;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public class AuthDataService : IAuthDataService
    {
        private readonly IAuthDataRepository _authDataRepository;

        public AuthDataService()
        {
            _authDataRepository = IocContainer.Default.Resolve<IAuthDataRepository>();
        }

        public void Execute(CreateAuthorizationDataCommand command)
        {
            var authData = _authDataRepository.GetById(command.Id);
            if (authData != null)
            {
                throw new Exception($"Authorization data with id {command.Id} was registered.");
            }

            var authDataInstance = new AuthorizationData(command.Id, command.UserId, command.ServiceKey,
                command.AuthorizationType, command.CreateTime);

            _authDataRepository.Save(authDataInstance, authDataInstance.Version);
        }
    }
}
