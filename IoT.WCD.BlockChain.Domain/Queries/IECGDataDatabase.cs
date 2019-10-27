using System;
using System.Collections.Generic;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public interface IECGDataDatabase:IReadOnlyDatabase<ECGDataDto>
    {
        List<ECGDataDto> GetECGDataByUserId(Guid userId);
    }
}
