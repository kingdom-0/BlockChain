using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers
{
    class PersonalDataUploadEventHandler : IEventHandler<PersonalDataUploadEvent>
    {
        public async Task Handle(PersonalDataUploadEvent @event)
        {
            //TODO: Some notification.
            //await BlogService.EnableJsPermission(@event.UserAlias);
        }
    }
}
