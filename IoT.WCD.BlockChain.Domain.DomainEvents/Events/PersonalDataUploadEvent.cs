using System;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.Events
{
    public class PersonalDataUploadEvent : IEvent
    {
        public Guid Id { get; }
        public string Parameter { get; set; }
    }
}
