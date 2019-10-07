using System;

namespace IoT.WCD.BlockChain.Application.DTOs
{
    public class PersonalDataUploadDto
    {
        public int Id { get; set; }

        public byte[] EcgData { get; set; }

        public byte[] ImpedanceData { get; set; }

        public int UserId { get; set; }

        public DateTime UploadTime { get; set; }
    }
}
