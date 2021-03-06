﻿using System;
using System.Collections.Generic;

namespace IoT.WCD.BlockChain.Entities.Interfaces
{
    public interface IBlock
    {
        List<byte> Data { get; }

        List<byte> Hash { get; set; }

        int Nonce { get; set; }

        List<byte> PreviousHash { get; set; }

        DateTime Timestamp { get; }

        List<byte> GenerateHash();

        List<byte> MineHash(byte[] difficulty);

        bool HasValidHash();

        bool HasValidPreviousHash(IBlock previousBlock);
    }
}
