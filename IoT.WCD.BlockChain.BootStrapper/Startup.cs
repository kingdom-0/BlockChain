using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace IoT.WCD.BlockChain.BootStrapper
{
    public class Startup
    {
        public static void Configure()
        {
            UnityContainer register = IocContainer.Default;
        }
    }
}
