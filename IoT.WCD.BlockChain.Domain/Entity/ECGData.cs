using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.WCD.BlockChain.Domain.Entity
{
    public class ECGData
    {
        public byte[] RawData { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
