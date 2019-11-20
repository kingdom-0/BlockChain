using System.Collections.Generic;

namespace IoT.WCD.BlockChain.Domain.Entities.Interfaces
{
    public interface IAuthDataBlockChain: IEnumerable<IAuthDataBlock>
    {
        int Count { get; }

        List<IAuthDataBlock> Blocks { get; set; }

        byte[] ProofOfWorkDifficulty { get; }

        void Add(IAuthDataBlock authDataBlock);

        bool IsValid();
    }
}
