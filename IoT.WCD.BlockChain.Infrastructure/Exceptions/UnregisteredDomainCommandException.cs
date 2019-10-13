using System;

namespace IoT.WCD.BlockChain.Infrastructure.Exceptions
{
    public class UnregisteredDomainCommandException:Exception
    {
        public UnregisteredDomainCommandException(string message) : base(message)
        {

        }
    }
}
