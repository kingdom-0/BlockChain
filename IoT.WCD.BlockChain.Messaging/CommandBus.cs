using IoT.WCD.BlockChain.Application.CommandHandlers;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Infrastructure.Exceptions;

namespace IoT.WCD.BlockChain.Messaging
{
    public class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public void Send<TCommand>(TCommand command) where TCommand : Command
        {
            var handler = _commandHandlerFactory.GetHandler<TCommand>();
            if (handler != null)
            {
                handler.Execute(command);
            }
            else
            {
                throw new UnregisteredDomainCommandException($"There was no handler with type {command.GetType()} registered.");
            }
        }

        public TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            //TODO:Implement logic..
            //var handler = _commandHandlerFactory.GetHandler<TCommand>();
            //if (handler != null)
            //{
            //    handler.Execute(command);
            //}
            return default;
        }
    }
}
