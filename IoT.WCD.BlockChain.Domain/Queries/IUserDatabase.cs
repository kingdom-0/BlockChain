using IoT.WCD.BlockChain.ValueObjects;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public interface IUserDatabase : IReadOnlyDatabase<UserDto>
    {
        UserDto GetByPhoneNumber(string phoneNumber);
    }
}
