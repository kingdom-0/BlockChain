using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Entities.Impl;
using IoT.WCD.BlockChain.Domain.Repositories.Mementos;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Domain.AggregateRoots
{
    [Serializable]
    public class AuthorizationData:AggregateRoot,IHandle<AuthDataCreatedEvent>,IOriginator
    {
        public static readonly AuthorizationData Dummy = new AuthorizationData(Guid.NewGuid(), Guid.Empty, string.Empty,
            AuthorizationType.None, DateTime.Now);

        public Guid UserId { get; set; }

        public string ServiceKey { get; set; }

        public AuthorizationType AuthorizationType { get; set; }

        public DateTime CreateTime { get; set; }

        public AuthorizationData()
        {
            
        }

        public AuthorizationData(Guid id, Guid userId,string serviceKey, AuthorizationType authorizationType, DateTime createTime)
        {
            Id = id;
            UserId = userId;
            ServiceKey = serviceKey;
            AuthorizationType = authorizationType;
            CreateTime = createTime;
            ApplyChange(new AuthDataCreatedEvent(Id, UserId, ServiceKey, AuthorizationType, CreateTime));
        }

        public void Handle(AuthDataCreatedEvent e)
        {
            Id = e.Id;
            UserId = e.UserId;
            ServiceKey = ServiceKey;
            AuthorizationType = e.AuthorizationType;
            CreateTime = e.CreateTime;
        }

        public Memento GetMemento()
        {
            return new AuthDataMemento(Id,UserId,ServiceKey,AuthorizationType,CreateTime);
        }

        public void SetMemento(Memento memento)
        {
            var authDataMemento = memento as AuthDataMemento;
            if (authDataMemento == null)
            {
                return;
            }

            Id = authDataMemento.Id;
            UserId = authDataMemento.UserId;
            ServiceKey = authDataMemento.ServiceKey;
            AuthorizationType = authDataMemento.AuthorizationType;
            CreateTime = authDataMemento.CreateTime;
        }

        public byte[] ToBytesArray()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            byte[] result;
            using (var ms = new MemoryStream())
            {
                binaryFormatter.Serialize(ms, this);
                result = ms.ToArray();
            }

            return result;
        }
    }
}
