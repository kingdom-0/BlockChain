﻿using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.ValueObjects;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public class UserDatabase : IUserDatabase
    {
        private static readonly List<UserDto> Users = new List<UserDto>();

        public UserDto GetById(Guid id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
        }

        public UserDto GetByPhoneNumber(string phoneNumber)
        {
            return Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
        }

        public void Add(UserDto item)
        {
            Users.Add(item);
        }

        public void Delete(Guid id)
        {
            Users.RemoveAll(x => x.Id == id);
        }

        public List<UserDto> GetItems()
        {
            return Users;
        }
    }
}
