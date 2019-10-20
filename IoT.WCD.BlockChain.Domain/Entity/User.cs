using System;

using IoT.WCD.BlockChain.Infrastructure.Enums;

namespace IoT.WCD.BlockChain.Domain.Entity
{
    public class User : AggregateRoot
    {
        public User()
        {
            
        }

        public User(Guid guid):base(guid)
        {
            
        }

        public string Name { get; internal set; }

        public string PhoneNumber { get; internal set; }

        public GenderType GenderType { get; internal set; }

        public string Address { get; internal set; }

        public DateTime CreateTime { get; private set; }
    }
}
