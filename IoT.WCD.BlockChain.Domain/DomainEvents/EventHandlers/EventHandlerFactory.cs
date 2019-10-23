using System;
using System.Collections.Generic;
using System.Linq;
using IoT.WCD.BlockChain.Domain.DomainEvents.Events;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers
{
    public class EventHandlerFactory : IEventHandlerFactory
    {

        public List<IEventHandler<T>> GetHandlers<T>() where T : IEvent
        {
            var handlerTypes = GetHandlerTypes<T>().ToList();

            var handlers = new List<IEventHandler<T>>();
            foreach (var eventHandler in handlerTypes)
            {
                handlers.Add((IEventHandler<T>) Activator.CreateInstance(eventHandler));
            }

            return handlers;
        }

        private static IEnumerable<Type> GetHandlerTypes<T>() where T : IEvent
        {
            var h1 = typeof(IEventHandler<T>).Assembly.GetExportedTypes();
            var h2 = typeof(IEventHandler<T>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<T>)));
            var h3 = typeof(IEventHandler<T>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<T>)))
                .Where(i => i.GetInterfaces()
                    .Any(ga => ga.GetGenericArguments().Any(t=>t==typeof(T))));
            var handlers = typeof(IEventHandler<T>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<T>)))
                .Where(i => i.GetInterfaces()
                    .Any(ga => ga.GetGenericArguments()
                        .Any(t => t == typeof(T)))).ToList();

            return handlers;
        }
    }
}
