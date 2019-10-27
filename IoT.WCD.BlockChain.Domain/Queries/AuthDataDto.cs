using System;
using IoT.WCD.BlockChain.Infrastructure.Enums;

namespace IoT.WCD.BlockChain.Domain.Queries
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
