using IoT.WCD.BlockChain.Application.CommandHandlers;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Infrastructure.Exceptions;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;

namespace IoT.WCD.BlockChain.Messaging
{
    public class CommandBus : ICommandBus
    {

        public CommandBus()
        {
        }

        public void Send<TCommand>(TCommand command) where TCommand : Command
        {
            var commandHandlerFactory = Ioc.Instance.Resolve<ICommandHandlerFactory>();
            var handler = commandHandlerFactory.GetHandler<TCommand>();
            if (handler != null)
            {
                handler.Execute(command);
            }
            else
            {
                throw new UnregisteredDomainCommandException($"There was no handler with type {command.GetType()} registered.");
            }
        }
    }
}
