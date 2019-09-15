using System;
using System.Linq;
using IoT.WCD.BlockChain.Entities.Impl;
using IoT.WCD.BlockChain.Entities.Interfaces;

namespace IoT.WCD.BlockChain.Entry
{
    class Program
    {
        private static readonly Random RandomGenerator = new Random(DateTime.Now.Millisecond);
        private static readonly IBlock GenesisBlock = new Block(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
        private static readonly byte[] ProofOfWorkDifficulty = { 0x00, 0x00 };
        static void Main()
        {
            IBlockChain chain = new Entities.Impl.BlockChain(ProofOfWorkDifficulty, GenesisBlock);
            //start mining 20 blocks in a loop
            for (var i = 0; i < 20; i++)
            {
                var data = Enumerable.Range(0, 256).Select(x => (byte)RandomGenerator.Next());
                chain.Add(new Block(data.ToArray()));
                Console.WriteLine(chain.LastOrDefault()?.ToString());
                Console.WriteLine($"Chain is valid : {chain.IsValid()}");
            }

            Console.ReadKey();
        }
    }
}
