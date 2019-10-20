using System;

namespace IoT.WCD.BlockChain.Domain.Entity
{
    public class ECGData
    {
        public byte[] RawData { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
