using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoT.WCD.BlockChain.Domain.DomainEvents;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain
{
    public class ApplyAggregateRoot:IAggregateRoot
    {
        private IEventBus _eventBus;

        public int Id { get; }

        public ApplyAggregateRoot()
        {
            
        }

        public ApplyAggregateRoot(string parameter)
        {
            //TODO:Validate logic.
        }

        protected bool Pass<TEvent>(TEvent @event)
            where TEvent:IEvent
        {
            //TODO:assign parameter
            _eventBus = IocContainer.Default.Resolve<IEventBus>();
             _eventBus.Publish(@event);
            return true;
        }

        public bool Deny(string reason)
        {
            return true;
        }
    }
}
