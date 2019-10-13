using System;

namespace IoT.WCD.BlockChain.Application.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
