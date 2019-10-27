using System;
using System.Collections.Generic;
using System.Linq;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public class AuthDataDatabase : IAuthDataDatabase
    {
        private static readonly List<AuthDataDto> AuthDatas = new List<AuthDataDto>();

        public AuthDataDto GetById(Guid id)
        {
            return AuthDatas.FirstOrDefault(x => x.Id == id);
        }

        public void Add(AuthDataDto item)
        {
            AuthDatas.Add(item);
        }

        public void Delete(Guid id)
        {
            AuthDatas.RemoveAll(x => x.Id == id);
        }

        public List<AuthDataDto> GetItems()
        {
            return AuthDatas;
        }
    }
}
