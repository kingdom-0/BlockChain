using System;
using IoT.WCD.BlockChain.Infrastructure.Enums;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.Events
{
    public class AuthDataCreatedEvent : Event
    {
        public Guid UserId { get; set; }
        public string ServiceKey { get; set; }

        public AuthorizationType AuthorizationType { get; set; }

        public DateTime CreateTime { get; set; }

        public AuthDataCreatedEvent(Guid aggregateId,Guid userId, string serviceKey, AuthorizationType authorizationType,DateTime createTime)
        {
            Id = Guid.NewGuid();
            AggregateId = aggregateId;
            UserId = userId;
            ServiceKey = serviceKey;
            AuthorizationType = authorizationType;
            CreateTime = createTime;
        }
    }
}
