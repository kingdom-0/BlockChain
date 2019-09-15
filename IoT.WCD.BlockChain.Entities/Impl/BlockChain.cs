using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Entities.Interfaces;

namespace IoT.WCD.BlockChain.Entities.Impl
{
    public class BlockChain : IEnumerable<IBlock>, IBlockChain
    {
        private List<IBlock> _blocks = new List<IBlock>();

        public int Count => _blocks.Count;

        public IBlock this[int index]
        {
            get => _blocks[index];
            set => _blocks[index] = value;
        }

        public List<IBlock> Blocks
        {
            get => _blocks;
            set => _blocks = value;
        }

        public byte[] Difficulty { get; }

        public BlockChain(byte[] difficulty, IBlock genesisBlock)
        {
            Difficulty = difficulty;
            genesisBlock.Hash = genesisBlock.MineHash(Difficulty);
            Blocks.Add(genesisBlock);
        }

        public void Add(IBlock block)
        {
            if (_blocks.LastOrDefault() != null)
            {
                block.PreviousHash = _blocks.LastOrDefault()?.Hash;
            }

            block.Hash = block.MineHash(Difficulty);
            Blocks.Add(block);
        }

        public bool IsValid()
        {
            return Blocks.Zip(Blocks.Skip(1), Tuple.Create)
                .All(block => block.Item2.HasValidHash() && block.Item2.HasValidPreviousHash(block.Item1));
        }

        public IEnumerator<IBlock> GetEnumerator()
        {
            return _blocks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _blocks.GetEnumerator();
        }
    }
}
