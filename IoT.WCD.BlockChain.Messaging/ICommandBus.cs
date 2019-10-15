using System.ComponentModel;
using IoT.WCD.BlockChain.Application.Commands;

namespace IoT.WCD.BlockChain.Messaging
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : Command;
    }
}
