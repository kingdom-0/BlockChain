using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain.Entities.Interfaces;

namespace IoT.WCD.BlockChain.Domain.Entities.Impl
{
    public class AuthDataBlockChain : IAuthDataBlockChain
    {
        private List<IAuthDataBlock> _blocks = new List<IAuthDataBlock>();

        public int Count => _blocks.Count;

        public IAuthDataBlock this[int index]
        {
            get => _blocks[index];
            set => _blocks[index] = value;
        }

        public List<IAuthDataBlock> Blocks
        {
            get => _blocks;
            set => _blocks = value;
        }

        public byte[] ProofOfWorkDifficulty { get; }

        public AuthDataBlockChain(byte[] proofOfWorkDifficulty, IAuthDataBlock genesisAuthDataBlock)
        {
            ProofOfWorkDifficulty = proofOfWorkDifficulty;
            genesisAuthDataBlock.Hash = genesisAuthDataBlock.MineHash(ProofOfWorkDifficulty);
            Blocks.Add(genesisAuthDataBlock);
        }

        public void Add(IAuthDataBlock authDataBlock)
        {
            if (_blocks.LastOrDefault() != null)
            {
                authDataBlock.PreviousHash = _blocks.LastOrDefault()?.Hash;
            }

            authDataBlock.Hash = authDataBlock.MineHash(ProofOfWorkDifficulty);
            Blocks.Add(authDataBlock);
        }

        public bool IsValid()
        {
            return Blocks.Zip(Blocks.Skip(1), Tuple.Create)
                .All(block => block.Item2.HasValidHash() && block.Item2.HasValidPreviousHash(block.Item1));
        }

        public IEnumerator<IAuthDataBlock> GetEnumerator()
        {
            return _blocks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _blocks.GetEnumerator();
        }
    }
}
