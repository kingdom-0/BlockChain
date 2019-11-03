using IoT.WCD.BlockChain.Domain.DomainEvents.Events;
using IoT.WCD.BlockChain.Domain.Queries;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;
using Unity;

namespace IoT.WCD.BlockChain.Domain.DomainEvents.EventHandlers
{
    public class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
    {
        private readonly IUserDatabase _userDatabase;

        public UserCreatedEventHandler()
        {
            _userDatabase = Ioc.Instance.Resolve<IUserDatabase>();
        }

        public void Handle(UserCreatedEvent handle)
        {
            var userDto = new UserDto
            {
                Id = handle.AggregateId,
                Version = handle.Version,
                Name = handle.Name,
                PhoneNumber = handle.PhoneNumber,
                GenderType = handle.GenderType,
                Address = handle.Address,
                CreateTime = handle.CreateTime
            };
            _userDatabase.Add(userDto);

            //TODO: Send email to target user.
        }
    }
}
