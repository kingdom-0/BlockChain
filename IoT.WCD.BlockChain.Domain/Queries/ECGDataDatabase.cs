using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain.Repositories.Storage;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public class ECGDataDatabase : IECGDataDatabase
    {
        private readonly IAuthDataStorage _authDataStorage;
        private static readonly List<ECGDataDto> EcgDatas = new List<ECGDataDto>();

        public ECGDataDatabase()
        {
            _authDataStorage = IocContainer.Default.Resolve<IAuthDataStorage>();
        }

        public ECGDataDto GetById(Guid id)
        {
            return EcgDatas.FirstOrDefault(x => x.Id == id);
        }

        public void Add(ECGDataDto item)
        {
            EcgDatas.Add(item);
        }

        public void Delete(Guid id)
        {
            EcgDatas.RemoveAll(x => x.Id == id);
        }

        public List<ECGDataDto> GetItems()
        {
            return EcgDatas;
        }

        public List<ECGDataDto> GetECGDataByUserId(Guid userId)
        {
            return EcgDatas.Where(x => x.UserId == userId).ToList();
        }
    }
}
