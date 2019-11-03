using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoT.WCD.BlockChain.Infrastructure.Enums;

namespace IoT.WCD.BlockChain.ValueObjects
{
    public class AuthDataDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string ServiceKey { get; set; }

        public AuthorizationType AuthorizationType { get; set; }

        public DateTime CreateTime { get; set; }

        public int Version { get; set; }
    }
}
