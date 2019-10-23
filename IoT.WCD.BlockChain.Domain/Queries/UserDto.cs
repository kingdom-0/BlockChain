using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoT.WCD.BlockChain.Infrastructure.Enums;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public int Version { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public GenderType GenerType { get; set; }

        public string Address { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
