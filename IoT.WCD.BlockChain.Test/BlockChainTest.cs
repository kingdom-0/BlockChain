using System;
using System.Linq;
using IoT.WCD.BlockChain.Entities.Impl;
using IoT.WCD.BlockChain.Entities.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IoT.WCD.BlockChain.Test
{
    [TestClass]
    public class BlockChainTest
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        private static readonly IBlock GenesisBlock = new Block(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00});
        private static readonly byte[] Difficulty = {0x00,0x00};

        private readonly Entities.Impl.BlockChain _chain = new Entities.Impl.BlockChain(Difficulty,GenesisBlock);

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
            var data = Enumerable.Range(0, 256).Select(x => (byte) Random.Next());
            _chain.Add(new Block(data.ToArray()));
            Assert.AreEqual(2,_chain.Blocks.Count);
        }
    }
}
