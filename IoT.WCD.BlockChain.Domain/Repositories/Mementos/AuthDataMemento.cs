using System;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Domain.Repositories.Mementos
{
    public class AuthDataMemento : Memento
    {
        public Guid UserId { get; set; }

        public string ServiceKey { get; set; }

        public AuthorizationType AuthorizationType { get; set; }

        public DateTime CreateTime { get; set; }

        public AuthDataMemento(Guid id, Guid userId, string serviceKey, AuthorizationType authorizationType,
            DateTime createTime)
        {
            Id = id;
            UserId = userId;
            ServiceKey = serviceKey;
            AuthorizationType = authorizationType;
            CreateTime = createTime;
        }
    }
}
