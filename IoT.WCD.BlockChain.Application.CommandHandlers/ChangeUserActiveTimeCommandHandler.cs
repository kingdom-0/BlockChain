using System;
using IoT.WCD.BlockChain.Application.Commands;
using IoT.WCD.BlockChain.Domain.Repositories.Repositories.Interfaces;
using IoT.WCD.BlockChain.Infrastructure.IoC.Contracts;

namespace IoT.WCD.BlockChain.Application.CommandHandlers
{
    public class ChangeUserActiveTimeCommandHandler : ICommandHandler<ChangeUserActiveTimeCommand>
    {
        public void Execute(ChangeUserActiveTimeCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var userRepository = Ioc.Instance.Resolve<IUserRepository>();
            if (userRepository == null)
            {
                throw new InvalidOperationException("User repository is not initialized.");
            }

            var user = userRepository.GetById(command.AggregateId);
            if (user.ActiveTime != command.NewActiveTime)
            {
                user.ChangeActiveTime(command.NewActiveTime);
            }

            userRepository.Save(user, command.Version);
        }
    }
}
