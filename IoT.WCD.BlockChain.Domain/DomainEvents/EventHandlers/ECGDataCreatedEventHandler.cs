using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Queries;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers
{
    public class ECGDataCreatedEventHandler : IEventHandler<ECGDataCreatedEvent>
    {
        private readonly IECGDataDatabase _ecgDataDatabase;

        public ECGDataCreatedEventHandler()
        {
            _ecgDataDatabase = IocContainer.Default.Resolve<IECGDataDatabase>();
        }

        public void Handle(ECGDataCreatedEvent @event)
        {
            var ecgDataDto = new ECGDataDto
            {
                Id = @event.AggregateId,
                UserId = @event.UserId,
                RawData = @event.RawData,
                ImpedanceData = @event.ImpedanceData,
                CreateTime = @event.CreateTime
            };

            _ecgDataDatabase.Add(ecgDataDto);

            //TODO: Send email to target user
        }
    }
}
