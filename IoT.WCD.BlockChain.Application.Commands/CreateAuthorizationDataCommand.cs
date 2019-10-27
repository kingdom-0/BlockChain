using System;
using IoT.WCD.BlockChain.Infrastructure.Enums;

namespace IoT.WCD.BlockChain.Application.Commands
{
    public class CreateAuthorizationDataCommand : Command
    {
        public Guid UserId { get; set; }

        public string ServiceKey { get; set; }

        public AuthorizationType AuthorizationType { get; set; }

        public DateTime CreateTime { get; set; }

        public CreateAuthorizationDataCommand(Guid id, Guid userId, string serviceKey,
            AuthorizationType authorizationType, int version) : base(id, version)
        {
            UserId = userId;
            ServiceKey = serviceKey;
            AuthorizationType = authorizationType;
            CreateTime = DateTime.Now;
        }
    }
}
