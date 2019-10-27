using System;
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
        private static readonly IBlock GenesisBlock = new Block(AuthorizationData.Dummy);
        private static readonly byte[] Difficulty = {0x00,0x00};

        private readonly Domain.Entities.Impl.BlockChain _chain = new Domain.Entities.Impl.BlockChain(Difficulty,GenesisBlock);

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
            _chain.Add(new Block(authorizationData));
            Assert.AreEqual(2,_chain.Blocks.Count);
        }
    }
}
