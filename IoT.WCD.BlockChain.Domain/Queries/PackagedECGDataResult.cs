using System.Collections.Generic;
using IoT.WCD.BlockChain.ValueObjects;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public class PackagedECGDataResult
    {
        public bool Result { get; }
        public List<ECGDataDto> EcgDataList { get; }
        public string Description { get; }

        public static PackagedECGDataResult Empty = new PackagedECGDataResult(false,new List<ECGDataDto>(),"Unknown" );

        public PackagedECGDataResult(bool result, IEnumerable<ECGDataDto> ecgDataList, string description)
        {
            Result = result;
            EcgDataList = new List<ECGDataDto>(ecgDataList);
            Description = description;
        }
    }
}
