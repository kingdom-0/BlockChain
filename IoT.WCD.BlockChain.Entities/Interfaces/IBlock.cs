using System;

namespace IoT.WCD.BlockChain.Entities.Interfaces
{
    public interface IBlock
    {
        byte[] Data { get; }

        byte[] Hash { get; set; }

        int Nonce { get; set; }

        byte[] PreviousHash { get; set; }

        DateTime Timestamp { get; }

        byte[] GenerateHash();

        byte[] MineHash(byte[] difficulty);

        bool HasValidHash();

        bool HasValidPreviousHash(IBlock previousBlock);
    }
}
