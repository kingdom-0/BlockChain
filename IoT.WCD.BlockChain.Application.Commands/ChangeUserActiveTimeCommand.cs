using System;

namespace IoT.WCD.BlockChain.Application.Commands
{
    public class ChangeUserActiveTimeCommand : Command
    {
        public Guid AggregateId { get; internal set; }
        public DateTime NewActiveTime { get; internal set; }

        public ChangeUserActiveTimeCommand(Guid id,Guid aggregateId, int version, DateTime newActiveTime) : base(id, version)
        {
            AggregateId = aggregateId;
            NewActiveTime = newActiveTime;
        }
    }
}
