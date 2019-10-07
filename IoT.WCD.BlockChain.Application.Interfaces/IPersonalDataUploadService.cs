using System.Threading.Tasks;
using IoT.WCD.BlockChain.Application.DTOs;

namespace IoT.WCD.BlockChain.Application.Interfaces
{
    public interface IPersonalDataUploadService
    {
        Task<bool> Upload(PersonalDataUploadDto personalDataUploadDto);
    }
}
