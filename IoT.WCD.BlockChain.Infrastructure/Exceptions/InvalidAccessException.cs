using System;

namespace IoT.WCD.BlockChain.Infrastructure.Exceptions
{
    public class InvalidAccessException : Exception
    {
        public InvalidAccessException()
        {
            
        }

        public InvalidAccessException(string message):base(message)
        {
            
        }
    }
}
