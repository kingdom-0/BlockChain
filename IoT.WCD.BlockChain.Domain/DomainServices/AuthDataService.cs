using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public class AuthDataService : IAuthDataService
    {

        public AuthDataService()
        {
            
        }

        public void Execute(CreateAuthorizationDataCommand command)
        {
            var authDataRepository = Ioc.Instance.Resolve<IAuthDataRepository>();
            var authData = authDataRepository.GetById(command.Id);
            if (authData != null)
            {
                throw new Exception($"Authorization data with id {command.Id} was registered.");
            }

            var authDataInstance = new AuthorizationData(command.Id, command.UserId, command.ServiceKey,
                command.AuthorizationType, command.CreateTime);

            authDataRepository.Save(authDataInstance, authDataInstance.Version);
        }
    }
}
