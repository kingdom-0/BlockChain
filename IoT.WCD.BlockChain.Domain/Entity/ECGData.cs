using System;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Repositories.Mementos;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Domain.Entity
{
    public class ECGData : AggregateRoot,IHandle<ECGDataCreatedEvent>,IOriginator
    {
        public Guid UserId { get; set; }

        public byte[] RawData { get; set; }

        public byte[] ImpedanceData { get; set; }

        public DateTime CreateTime { get; set; }

        public ECGData()
        {
            
        }

        public ECGData(Guid id, Guid userId, byte[] rawData, byte[] impedanceData, DateTime createTime):base(id)
        {
            UserId = userId;
            RawData = rawData;
            ImpedanceData = impedanceData;
            CreateTime = createTime;
            ApplyChange(new ECGDataCreatedEvent(id,UserId,RawData,ImpedanceData,CreateTime));
        }

        public void Handle(ECGDataCreatedEvent e)
        {
            UserId = e.UserId;
            RawData = e.RawData;
            ImpedanceData = e.ImpedanceData;
            CreateTime = e.CreateTime;
        }

        public Memento GetMemento()
        {
            return new ECGDataMemento(Id,UserId,RawData,ImpedanceData,CreateTime);
        }

        public void SetMemento(Memento memento)
        {
            var ecgDataMemento = memento as ECGDataMemento;
            if (ecgDataMemento == null)
            {
                return;
            }

            Id = ecgDataMemento.Id;
            UserId = ecgDataMemento.UserId;
            RawData = ecgDataMemento.RawData;
            ImpedanceData = ecgDataMemento.ImpedanceData;
            CreateTime = ecgDataMemento.CreateTime;
        }
    }
}
