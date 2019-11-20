using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Entities.Interfaces;

namespace IoT.WCD.BlockChain.Domain.Entities.Impl
{
    public class AuthDataBlock : IAuthDataBlock
    {
        public AuthDataBlock(AuthorizationData authorizationData)
        {
            Data = authorizationData ?? throw new ArgumentNullException(nameof(authorizationData));
            Nonce = 0;
            PreviousHash = new List<byte>() {0x00};
            Timestamp = DateTime.Now;
        }

        public AuthorizationData Data { get; }
        public List<byte> Hash { get; set; }
        public int Nonce { get; set; }
        public List<byte> PreviousHash { get; set; }
        public DateTime Timestamp { get; }

        public List<byte> GenerateHash()
        {
            var sha256 = new SHA256Managed();
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(Data.ToBytesArray());
                    writer.Write(Nonce);
                    writer.Write(Timestamp.ToBinary());
                    writer.Write(PreviousHash.ToArray());
                    var streamArray = stream.ToArray();
                    return sha256.ComputeHash(streamArray).ToList();
                }
            }
        }

        public List<byte> MineHash(byte[] difficulty)
        {
            if (difficulty == null)
            {
                throw new ArgumentNullException(nameof(difficulty));
            }

            var hash = new List<byte>();
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

        public bool HasValidPreviousHash(IAuthDataBlock previousAuthDataBlock)
        {
            if (previousAuthDataBlock == null)
            {
                throw new ArgumentNullException(nameof(previousAuthDataBlock));
            }

            var previousBlockHash = previousAuthDataBlock.GenerateHash();
            return previousAuthDataBlock.HasValidHash() && PreviousHash.SequenceEqual(previousBlockHash);
        }

        public override string ToString()
        {
            return $"Hash     :{BitConverter.ToString(Hash.ToArray()).Replace("-", "")}\n" +
                   $"Pre Hash :{BitConverter.ToString(PreviousHash.ToArray()).Replace("-", "")}\n" +
                   $"Nonce    :{Nonce}\n" +
                   $"Timestamp:{Timestamp:yyyy/MM/dd HH:mm:ss.fff}\n\r";
        }
    }
}
