using System;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public class ECGDataDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public byte[] RawData { get; set; }

        public byte[] ImpedanceData { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
