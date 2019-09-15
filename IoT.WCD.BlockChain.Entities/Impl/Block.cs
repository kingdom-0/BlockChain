using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using IoT.WCD.BlockChain.Entities.Interfaces;

namespace IoT.WCD.BlockChain.Entities.Impl
{
    public class Block:IBlock
    {
        public Block(byte[] data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            Nonce = 0;
            PreviousHash = new byte[]{ 0x00 };
            Timestamp = DateTime.Now;
        }
        public byte[] Data { get; }
        public byte[] Hash { get; set; }
        public int Nonce { get; set; }
        public byte[] PreviousHash { get; set; }
        public DateTime Timestamp { get; }


        public byte[] GenerateHash()
        {
            var sha512 = new SHA256Managed();
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(Data);
                    writer.Write(Nonce);
                    writer.Write(Timestamp.ToBinary());
                    writer.Write(PreviousHash);
                    var streamArray = stream.ToArray();
                    return sha512.ComputeHash(streamArray);
                }
            }
        }

        public byte[] MineHash(byte[] difficulty)
        {
            if (difficulty == null)
            {
                throw new ArgumentNullException(nameof(difficulty));
            }

            var hash = new byte[0];
            var difficultyLength = difficulty.Length;
            while (!hash.Take(difficultyLength).SequenceEqual(difficulty) && Nonce <= int.MaxValue)
            {
                Nonce++;
                hash = GenerateHash();
            }

            return hash;
        }

        public bool HasValidHash()
        {
            var currentHash = GenerateHash();
            return Hash.SequenceEqual(currentHash);
        }

        public bool HasValidPreviousHash(IBlock previousBlock)
        {
            if (previousBlock == null)
            {
                throw new ArgumentNullException(nameof(previousBlock));
            }

            var previousBlockHash = previousBlock.GenerateHash();
            return previousBlock.HasValidHash() && PreviousHash.SequenceEqual(previousBlockHash);
        }

        public override string ToString()
        {
            return $"Hash     :{BitConverter.ToString(Hash).Replace("-", "")}\n" +
                   $"Pre Hash :{BitConverter.ToString(PreviousHash).Replace("-", "")}\n" +
                   $"Nonce    :{Nonce}\n" +
                   $"Timestamp:{Timestamp:yyyy/MM/dd HH:mm:ss.fff}\n\r";
        }
    }
}
