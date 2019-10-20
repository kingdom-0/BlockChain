using IoT.WCD.BlockChain.Application.Commands;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public interface IUserService
    {
        void Execute(CreateUserCommand createUserCommand);
    }
}
