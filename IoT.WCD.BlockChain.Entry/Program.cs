using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Entities.Impl;
using IoT.WCD.BlockChain.Domain.Entities.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.Enums;

namespace IoT.WCD.BlockChain.Entry
{
    class Program
    {
        private static readonly Random RandomGenerator = new Random(DateTime.Now.Millisecond);
        private static readonly IBlock GenesisBlock = new Block(AuthorizationData.Dummy);
        private static readonly byte[] ProofOfWorkDifficulty = { 0x00, 0x00 };
        static void Main()
        {
            IBlockChain chain = new Domain.Entities.Impl.BlockChain(ProofOfWorkDifficulty, GenesisBlock);
            //start mining 20 blocks in a loop
            for (var i = 0; i < 20; i++)
            {
                var authorizationData = new AuthorizationData(Guid.NewGuid(), Guid.Empty, "test key",
                    AuthorizationType.ReadAndWrite, DateTime.Now);
                chain.Add(new Block(authorizationData));
                Console.WriteLine(chain.LastOrDefault()?.ToString());
                Console.WriteLine($"Chain is valid : {chain.IsValid()}");
            }

            Console.ReadKey();
        }
    }
}
