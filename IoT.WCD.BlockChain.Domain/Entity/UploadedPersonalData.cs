namespace IoT.WCD.BlockChain.Domain.Entity
{
    public class UploadedPersonalData : AggregateRoot
    {
        //TODO: Add data validation.
        public bool IsValid()
        {
            return true;
        }
    }
}
