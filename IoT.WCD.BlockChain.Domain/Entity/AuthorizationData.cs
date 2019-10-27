using System;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Repositories.Mementos;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Domain.Entity
{
    public class AuthorizationData:AggregateRoot,IHandle<AuthDataCreatedEvent>,IOriginator
    {
        public Guid UserId { get; set; }

        public string ServiceKey { get; set; }

        public AuthorizationType AuthorizationType { get; set; }

        public DateTime CreateTime { get; set; }

        public AuthorizationData()
        {
            
        }

        public AuthorizationData(Guid id, Guid userId,string serviceKey, AuthorizationType authorizationType, DateTime createTime)
        {
            Id = id;
            UserId = userId;
            ServiceKey = serviceKey;
            AuthorizationType = authorizationType;
            CreateTime = createTime;
            ApplyChange(new AuthDataCreatedEvent(Id, UserId, ServiceKey, AuthorizationType, CreateTime));
        }

        public void Handle(AuthDataCreatedEvent e)
        {
            Id = e.Id;
            UserId = e.UserId;
            ServiceKey = ServiceKey;
            AuthorizationType = e.AuthorizationType;
            CreateTime = e.CreateTime;
        }

        public Memento GetMemento()
        {
            return new AuthDataMemento(Id,UserId,ServiceKey,AuthorizationType,CreateTime);
        }

        public void SetMemento(Memento memento)
        {
            var authDataMemento = memento as AuthDataMemento;
            if (authDataMemento == null)
            {
                return;
            }

            Id = authDataMemento.Id;
            UserId = authDataMemento.UserId;
            ServiceKey = authDataMemento.ServiceKey;
            AuthorizationType = authDataMemento.AuthorizationType;
            CreateTime = authDataMemento.CreateTime;
        }
    }
}
