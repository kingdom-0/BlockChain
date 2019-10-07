using System;
using System.Threading.Tasks;
using IoT.WCD.BlockChain.Application.DTOs;
using IoT.WCD.BlockChain.Application.Interfaces;

namespace IoT.WCD.BlockChain.Application.Services
{
    public class PersonalDataUploadService : IPersonalDataUploadService
    {
        public Task<bool> Upload(PersonalDataUploadDto personalDataUploadDto)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
