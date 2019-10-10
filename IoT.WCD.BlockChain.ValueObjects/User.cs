using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.WCD.BlockChain.ValueObjects
{
    public class User
    {
        public int Id { get; set; }

        public string RealName { get; set; }

        public string Alias { get; set; }

        public DateTime? RegisterTime { get; set; }

    }
}
