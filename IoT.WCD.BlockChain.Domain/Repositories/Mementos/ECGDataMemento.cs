using System;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Domain.Repositories.Mementos
{
    public class ECGDataMemento : Memento
    {
        public Guid UserId { get; internal set; }

        public byte[] RawData { get;internal  set; }

        public byte[] ImpedanceData { get;internal  set; }

        public DateTime CreateTime { get;internal  set; }

        public ECGDataMemento(Guid id, Guid userId, byte[] rawData,
            byte[] impedanceData,DateTime createTime)
        {
            Id = id;
            UserId = userId;
            RawData = rawData;
            ImpedanceData = impedanceData;
            CreateTime = createTime;
        }
    }
}
