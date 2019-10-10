namespace IoT.WCD.BlockChain.Domain.DomainEvents.Events
{
    public class PersonalDataUploadEvent : IEvent
    {
        public string Parameter { get; set; }
    }
}
