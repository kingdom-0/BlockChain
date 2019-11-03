using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Queries;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers
{
    class UserActiveTimeChangedEventHandler:IEventHandler<UserActiveTimeChangedEvent>
    {
        public void Handle(UserActiveTimeChangedEvent @event)
        {
            var userDb = Ioc.Instance.Resolve<IUserDatabase>();
            var userDto = userDb.GetById(@event.AggregateId);
            userDto.ActiveTime = @event.NewActiveTime;
            userDto.Version = @event.Version;
        }
    }
}
