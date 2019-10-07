using System;
using System.Threading.Tasks;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public class UploadPersonalDataService : IUploadPersonalDataService
    {
        public Task<string> VerifyDuplicatedData(object user, DateTime uploadTime)
        {
            //TODO: Verify via repository.
            throw new NotImplementedException();
        }
    }
}
