using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Queries;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers
{
    public class ECGDataCreatedEventHandler : IEventHandler<ECGDataCreatedEvent>
    {
        public ECGDataCreatedEventHandler()
        {
            
        }

        public void Handle(ECGDataCreatedEvent @event)
        {
            var ecgDataDatabase = Ioc.Instance.Resolve<IECGDataDatabase>();
            var ecgDataDto = new ECGDataDto
            {
                Id = @event.AggregateId,
                UserId = @event.UserId,
                RawData = @event.RawData,
                ImpedanceData = @event.ImpedanceData,
                CreateTime = @event.CreateTime
            };

            ecgDataDatabase.Add(ecgDataDto);

            //TODO: Send email to target user
        }
    }
}
