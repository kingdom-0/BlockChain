﻿using System;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Repository.Mementos;

namespace IoT.WCD.BlockChain.Domain.Repositories.Mementos
{
    [Serializable]
    public class UserMemento : Memento
    {
        public string Name { get; internal set; }

        public string PhoneNumber { get; internal set; }

        public GenderType GenderType { get; internal set; }

        public string Address { get; internal set; }

        public DateTime CreateTime { get; internal set; }

        public Guid AccessToken { get; internal set; }

        public UserMemento(Guid id,string name, string phoneNumber,GenderType genderType,
            string address, DateTime createTime, int eventVersion)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            GenderType = genderType;
            Address = address;
            CreateTime = createTime;
            EventVersion = eventVersion;
        }
    }
}
