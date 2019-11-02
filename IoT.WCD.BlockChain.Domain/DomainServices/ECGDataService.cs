using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.AggregateRoots;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public class ECGDataService:IECGDataService
    {

        public ECGDataService()
        {
            
        }

        public void Execute(CreateECGDataCommand command)
        {
            var  ecgDataRepository = Ioc.Instance.Resolve<IECGDataRepository>();
            var ecgData = ecgDataRepository.GetById(command.Id);
            if (ecgData != null)
            {
                throw new Exception("ECG data was added.");
            }

            var ecgDataInstance = new ECGData(command.Id,command.UserId,command.RawData,command.ImpedanceData,command.CreateTime);
            ecgDataRepository.Save(ecgDataInstance,ecgDataInstance.Version);

        }
    }
}
