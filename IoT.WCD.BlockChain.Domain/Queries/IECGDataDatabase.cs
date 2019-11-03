using System;
using System.Collections.Generic;
using IoT.WCD.BlockChain.ValueObjects;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public interface IECGDataDatabase:IReadOnlyDatabase<ECGDataDto>
    {
        PackagedECGDataResult GetUserECGDataByServiceKey(Guid userId, string serviceKey);

        List<ECGDataDto> GetUserEcgDataByToken(Guid userId, string secretToken);
    }
}
