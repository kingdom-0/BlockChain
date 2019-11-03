using System;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.Events
{
    public class UserActiveTimeChangedEvent:Event
    {
        public DateTime NewActiveTime { get; internal set; }

        public UserActiveTimeChangedEvent(DateTime newActiveTime)
        {
            NewActiveTime = newActiveTime;
        }
    }
}
