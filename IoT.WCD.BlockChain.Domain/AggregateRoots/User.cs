using System;
using System.Linq;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Repositories.Mementos;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Infrastructure.Utilities;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Domain.AggregateRoots
{
    public class User : AggregateRoot,IHandle<UserCreatedEvent>,
        IHandle<UserActiveTimeChangedEvent>,
        IOriginator
    {
        private Guid _privateKey;
        public User()
        {
            
        }

        public User(Guid id, string name, string phoneNumber, string address, GenderType genderType):base(id)
        {
            _privateKey = Guid.NewGuid();
            ActiveTime = DateTime.Now;
            ApplyChange(new UserCreatedEvent(id,name,phoneNumber,address,DateTime.Now, _privateKey));
        }

        public string Name { get; internal set; }

        public string PhoneNumber { get; internal set; }

        public GenderType GenderType { get; internal set; }

        public string Address { get; internal set; }

        public DateTime CreateTime { get; private set; }

        //智能合约
        public DateTime ActiveTime { get; private set; }

        public string GetUserKey()
        {
            return _privateKey.ToString().GetReverseData();
        }

        public bool KeyIsValid(string inputKey)
        {
            return _privateKey.ToString() == inputKey;
        }

        public void Handle(UserCreatedEvent e)
        {
            Id = e.AggregateId;
            Name = e.Name;
            PhoneNumber = e.PhoneNumber;
            Address = e.Address;
            GenderType = e.GenderType;
            _privateKey = e.AccessToken;
        }

        public void ChangeActiveTime(DateTime newActiveTime)
        {
            ActiveTime = newActiveTime;
            ApplyChange(new UserActiveTimeChangedEvent(newActiveTime));
        }

        public Memento GetMemento()
        {
           return new UserMemento(Id,Name,PhoneNumber,GenderType,Address,CreateTime,Version);
        }

        public void SetMemento(Memento memento)
        {
            var userMemento = memento as UserMemento;
            if (userMemento == null)
            {
                return;
            }

            Id = userMemento.Id;
            Name = userMemento.Name;
            PhoneNumber = userMemento.PhoneNumber;
            Address = userMemento.Address;
            GenderType = userMemento.GenderType;
            Version = userMemento.Version;
            _privateKey = userMemento.AccessToken;
        }

        public void Handle(UserActiveTimeChangedEvent e)
        {
            ActiveTime = e.NewActiveTime;
        }
    }
}
