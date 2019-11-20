using System;
using System.Linq;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Entities.Impl;
using IoT.WCD.BlockChain.Domain.Entities.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IoT.WCD.BlockChain.Test
{
    [TestClass]
    public class BlockChainTest
    {
        private static readonly IAuthDataBlock GenesisAuthDataBlock = new AuthDataBlock(AuthorizationData.Dummy);
        private static readonly byte[] Difficulty = {0x00,0x00};

        private readonly AuthDataBlockChain _chain = new AuthDataBlockChain(Difficulty,GenesisAuthDataBlock);

        [TestMethod]
        public void TestBlockChainConstructor()
        {
            Assert.IsNotNull(_chain);
        }

        [TestMethod]
        public void TestBlockChainGenesisBlock()
        {
            Assert.AreEqual(1,_chain.Blocks.Count);
        }

        [TestMethod]
        public void TestBlockChainNewBlock()
        {
            var authorizationData = new AuthorizationData(Guid.NewGuid(), Guid.Empty, "test key",
                AuthorizationType.ReadAndWrite, DateTime.Now);
            _chain.Add(new AuthDataBlock(authorizationData));
            Assert.AreEqual(2,_chain.Blocks.Count);
        }

        [TestMethod]
        public void TestBlockChainAuthorizationData()
        {
            var authData = _chain.Blocks.FirstOrDefault(x => x.Data.ServiceKey == "test key");
            Assert.IsNotNull(authData);
        }
    }
}
