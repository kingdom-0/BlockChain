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
        private readonly IECGDataRepository _ecgDataRepository;

        public ECGDataService()
        {
            _ecgDataRepository = IocContainer.Default.Resolve<IECGDataRepository>();
        }

        public void Execute(CreateECGDataCommand command)
        {
            var ecgData = _ecgDataRepository.GetById(command.Id);
            if (ecgData != null)
            {
                throw new Exception("ECG data was added.");
            }

            var ecgDataInstance = new ECGData(command.Id,command.UserId,command.RawData,command.ImpedanceData,command.CreateTime);
            _ecgDataRepository.Save(ecgDataInstance,ecgDataInstance.Version);

        }
    }
}
