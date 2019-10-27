using System;
using IoT.WCD.BlockChain.Infrastructure.Enums;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.Events
{
    [Serializable]
    public class UserCreatedEvent : Event
    {
        public string Name { get; internal set; }

        public string PhoneNumber { get; internal set; }

        public string Address { get; internal set; }

        public GenderType GenderType { get; internal set; }

        public DateTime CreateTime { get; internal set; }

        public UserCreatedEvent(Guid aggregateId, string name, string phoneNumber, string address, DateTime createTime)
        {
            Id = Guid.NewGuid();
            AggregateId = aggregateId;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            CreateTime = createTime;
        }
    }
}
