using System;
using System.Collections.Generic;
using IoT.WCD.BlockChain.Domain.AggregateRoots;

namespace IoT.WCD.BlockChain.Domain.Entities.Interfaces
{
    public interface IAuthDataBlock
    {
        AuthorizationData Data { get; }

        List<byte> Hash { get; set; }

        int Nonce { get; set; }

        List<byte> PreviousHash { get; set; }

        DateTime Timestamp { get; }

        List<byte> GenerateHash();

        List<byte> MineHash(byte[] difficulty);

        bool HasValidHash();

        bool HasValidPreviousHash(IAuthDataBlock previousAuthDataBlock);
    }
}
