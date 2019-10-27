using IoT.WCD.BlockChain.Application.Commands;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public interface IDomainService<T> where T:Command
    {
        void Execute(T command);
    }
}
