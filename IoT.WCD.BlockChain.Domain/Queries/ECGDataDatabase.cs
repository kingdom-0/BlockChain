using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Domain.Repositories.Storage;
using IoT.WCD.BlockChain.Infrastructure.Enums;
using IoT.WCD.BlockChain.Infrastructure.Exceptions;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using IoT.WCD.BlockChain.Infrastructure.Utilities;
using Unity;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public class ECGDataDatabase : IECGDataDatabase
    {

        private static readonly List<ECGDataDto> EcgDatas = new List<ECGDataDto>();
        private readonly IUserRepository _userRepository;
        public ECGDataDatabase()
        {
            _userRepository = Ioc.Instance.Resolve<IUserRepository>();
        }

        public PackagedECGDataResult GetUserECGDataByServiceKey(Guid userId, string serviceKey)
        {
            var user = _userRepository.GetById(userId);
            if (DateTime.Now.Subtract(user.ActiveTime).TotalDays >= 7)
            {
                var ecgData = EcgDatas.Where(x => x.UserId == userId);
                return new PackagedECGDataResult(true,ecgData,"Intelligent contract came into effect, Retrieve ECG data successfully.");
            }

            var authDataStorage = Ioc.Instance.Resolve<IAuthDataStorage>();
            var authData = authDataStorage.GetByUserId(userId, serviceKey) as AuthorizationData;
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

        public List<ECGDataDto> GetUserEcgDataByToken(Guid userId, string secretToken)
        {
            var userRepository = Ioc.Instance.Resolve<IUserRepository>();

            var user = userRepository.GetById(userId);
            if (user.KeyIsValid(secretToken))
            {
                return EcgDatas;
            }

            throw new InvalidAccessException("Invalid secret token.");
        }


        public ECGDataDto GetById(Guid id)
        {
            return null;
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
