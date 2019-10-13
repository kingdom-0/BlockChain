using Unity;

namespace IoT.WCD.BlockChain.Infrastructure.IoC.Contracts
{
    public class IocContainer
    {
        public static UnityContainer Default = new UnityContainer();

        private IocContainer()
        {

        }
    }
}
