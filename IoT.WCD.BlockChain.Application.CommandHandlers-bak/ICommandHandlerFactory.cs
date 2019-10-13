using IoT.WCD.BlockChain.Application.Commands;

namespace IoT.WCD.BlockChain.Application.CommandHandlers
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}
