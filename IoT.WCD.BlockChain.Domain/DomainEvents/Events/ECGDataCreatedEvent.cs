using System;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.Events
{
    [Serializable]
    public class ECGDataCreatedEvent : Event
    {
        public Guid UserId { get; set; }

        public byte[] RawData { get; set; }

        public byte[] ImpedanceData { get; set; }

        public DateTime CreateTime { get; set; }

        public ECGDataCreatedEvent(Guid aggregateId, Guid userId, byte[] rawData, byte[] impedanceData, DateTime createTime)
        {
            Id = Guid.NewGuid();
            AggregateId = aggregateId;
            UserId = userId;
            RawData = rawData;
            ImpedanceData = impedanceData;
            CreateTime = createTime;
        }
    }
}
