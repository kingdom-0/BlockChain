using System;
using IoT.WCD.BlockChain.Domain.AggregateRoots;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public interface IECGDataDatabase:IReadOnlyDatabase<ECGDataDto>
    {
        PackagedECGDataResult GetECGDataByUserId(Guid userId, string serviceKey);
    }
}
