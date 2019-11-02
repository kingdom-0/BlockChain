using System;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Queries;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers
{
    public class AuthDataCreatedEventHandler : IEventHandler<AuthDataCreatedEvent>
    {

        public AuthDataCreatedEventHandler()
        {
            
        }

        public void Handle(AuthDataCreatedEvent @event)
        {
            var authDataDatabase = Ioc.Instance.Resolve<IAuthDataDatabase>();
            var authDataDto = new AuthDataDto
            {
                Id = @event.AggregateId,
                UserId = @event.UserId,
                ServiceKey = @event.ServiceKey,
                AuthorizationType = @event.AuthorizationType,
                CreateTime = @event.CreateTime,
                Version = @event.Version
            };

            authDataDatabase.Add(authDataDto);

            //TODO: Send email to target user. 
        }
    }
}
