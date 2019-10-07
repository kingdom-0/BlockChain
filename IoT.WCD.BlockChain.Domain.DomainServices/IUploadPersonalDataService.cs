using System;
using System.Threading.Tasks;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public interface IUploadPersonalDataService
    {
        Task<string> VerifyDuplicatedData(object user, DateTime uploadTime);
    }
}
