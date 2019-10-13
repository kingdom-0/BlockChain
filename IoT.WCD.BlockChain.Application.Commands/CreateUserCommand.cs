using System;
using IoT.WCD.BlockChain.Infrastructure.Enums;

namespace IoT.WCD.BlockChain.Application.Commands
{
    public class CreateUserCommand : Command
    {
        public string Name { get; internal set; }

        public string PhoneNumber { get; internal set; }

        public GenderType GenderType { get; internal set; }

        public string Address { get; internal set; }

        public DateTime CreateTime { get; private set; }

        public CreateUserCommand(Guid aggregateId, string name, string phoneNumber, GenderType genderType,
            string address, int version)
            : base(aggregateId, version)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            GenderType = genderType;
            Address = address;
            CreateTime = DateTime.Now;
        }
    }
}
