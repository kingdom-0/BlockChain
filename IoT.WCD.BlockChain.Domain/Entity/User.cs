﻿using System;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Repositories.Mementos;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Domain.Entity
{
    public class User : AggregateRoot,IHandle<UserCreatedEvent>,IOriginator
    {
        public User()
        {
            
        }

        public User(Guid id, string name, string phoneNumber, string address, GenderType genderType):base(id)
        {
            ApplyChange(new UserCreatedEvent(id,name,phoneNumber,address,DateTime.Now));
        }

        public string Name { get; internal set; }

        public string PhoneNumber { get; internal set; }

        public GenderType GenderType { get; internal set; }

        public string Address { get; internal set; }

        public DateTime CreateTime { get; private set; }

        public void Handle(UserCreatedEvent e)
        {
            Id = e.AggregateId;
            Name = e.Name;
            PhoneNumber = e.PhoneNumber;
            Address = e.Address;
            GenderType = e.GenderType;
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
        }
    }
}
