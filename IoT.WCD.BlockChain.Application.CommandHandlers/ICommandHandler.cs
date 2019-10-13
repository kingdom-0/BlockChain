using IoT.WCD.BlockChain.Application.Commands;

namespace IoT.WCD.BlockChain.Application.CommandHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }

    public interface ICommandHandler<in TCommand, out TResult> where TCommand : ICommand
    {
        TResult Execute(TCommand command);
    }
}
