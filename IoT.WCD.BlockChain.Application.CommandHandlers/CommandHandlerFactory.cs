using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Application.Commands;

namespace IoT.WCD.BlockChain.Application.CommandHandlers
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            var handlers = GetHandlerTypes<T>().ToList();

            var commandHandler = handlers.Select(handler =>
                (ICommandHandler<T>) Activator.CreateInstance(handler)).FirstOrDefault();

            return commandHandler;
        }

        private static IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {
            var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                .Where(i => i.GetInterfaces()
                    .Any(ga => ga.GetGenericArguments()
                        .Any(t => t == typeof(T)))).ToList();

            return handlers;
        }
    }
}
