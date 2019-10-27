using System;

namespace IoT.WCD.BlockChain.Application.Commands
{
    public class CreateECGDataCommand : Command
    {
        public Guid UserId { get; set; }

        public byte[] RawData { get; set; }

        public byte[] ImpedanceData { get; set; }

        public DateTime CreateTime { get; set; }

        public CreateECGDataCommand(Guid userId, byte[] rawData, byte[] impedanceData,
            DateTime createTime, Guid id, int version) : base(id, version)
        {
            UserId = userId;
            RawData = rawData;
            ImpedanceData = impedanceData;
            CreateTime = createTime;
        }
    }
}
