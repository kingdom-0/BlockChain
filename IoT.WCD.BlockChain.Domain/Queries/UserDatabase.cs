using System;
using System.Collections.Generic;
using System.Linq;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public class UserDatabase : IUserDatabase
    {
        private static readonly List<UserDto> Users = new List<UserDto>();

        public UserDto GetById(Guid id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
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
