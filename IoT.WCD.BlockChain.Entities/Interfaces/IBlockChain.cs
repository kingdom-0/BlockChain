using System.Collections.Generic;

namespace IoT.WCD.BlockChain.Entities.Interfaces
{
    public interface IBlockChain: IEnumerable<IBlock>
    {
        int Count { get; }

        List<IBlock> Blocks { get; set; }

        byte[] ProofOfWorkDifficulty { get; }

        void Add(IBlock block);

        bool IsValid();
    }
}
