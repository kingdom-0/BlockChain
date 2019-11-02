using System;
using System.Collections.Generic;

namespace IoT.WCD.BlockChain.Infrastructure.IoC.Contracts
{
    public class Ioc
    {
        private readonly Dictionary<Type, object> _instances;
        private static Ioc _instance;

        private Ioc()
        {
            _instances = new Dictionary<Type, object>(); 
        }

        public static Ioc Instance
        {
            get { return _instance ?? (_instance = new Ioc()); }
        }

        public void RegisterType<T>(Type type, T serviceInstance) where T : class
        {
            if (_instances.ContainsKey(type))
            {
                return;
            }
            _instances[type] = serviceInstance;
        }

        public T Resolve<T>() where T :class
        {
            var type = typeof(T);
            if (_instances.ContainsKey(type))
            {
                return _instances[type] as T;
            }
            
            throw new KeyNotFoundException(string.Format("Service with type {0} is not found!", type));
        }
    }
}
