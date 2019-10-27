using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Entities.Impl;
using IoT.WCD.BlockChain.Domain.Entities.Interfaces;

namespace IoT.WCD.BlockChain.Domain.Repositories.Storage
{
    public class InMemoryAuthDataStorage : IAuthDataStorage
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        private static readonly IBlock GenesisBlock = new Block(AuthorizationData.Dummy);
        private static readonly byte[] Difficulty = {0x00,0x00};

        private readonly Entities.Impl.BlockChain _chain = new Entities.Impl.BlockChain(Difficulty,GenesisBlock);


        public void Save(IAggregateRoot aggregate)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            var authorizationData = aggregate as AuthorizationData;
            if (authorizationData == null)
            {
                return;
            }
            using (var ms = new MemoryStream())
            {
                binaryFormatter.Serialize(ms, authorizationData);
                var block = new Block(authorizationData);
                _chain.Add(block);
            }
        }
    }
}
