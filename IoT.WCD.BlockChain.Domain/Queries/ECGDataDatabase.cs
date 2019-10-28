using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Repositories.Storage;
using IoT.WCD.BlockChain.Infrastructure.Enums;
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

        public PackagedECGDataResult GetECGDataByUserId(Guid userId, string serviceKey)
        {
            var authData = _authDataStorage.GetByUserId(userId, serviceKey) as AuthorizationData;
            if (authData == null)
            {
                return PackagedECGDataResult.Empty;
            }

            if (authData.AuthorizationType == AuthorizationType.Read ||
                authData.AuthorizationType == AuthorizationType.ReadAndWrite)
            {
                var ecgData = EcgDatas.Where(x => x.UserId == userId);
                return new PackagedECGDataResult(true,ecgData,"Retrieve ECG data successfully.");
            }
            else
            {
                return new PackagedECGDataResult(false, new List<ECGDataDto>(),
                    "You have no authorization to gain user ECG data.");
            }
        }


        public ECGDataDto GetById(Guid id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
