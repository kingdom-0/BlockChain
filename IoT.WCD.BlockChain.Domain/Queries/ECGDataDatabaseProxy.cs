using System;
using System.Collections.Generic;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public class ECGDataDatabaseProxy:IECGDataDatabaseProxy
    {
        private readonly IECGDataDatabase _ecgDataDatabase;

        public ECGDataDatabaseProxy()
        {
            
        }
        public ECGDataDto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(ECGDataDto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ECGDataDto> GetItems()
        {
            throw new NotImplementedException();
        }

        public List<ECGDataDto> GetECGDataByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
