﻿using System;
using System.Collections.Generic;

namespace IoT.WCD.BlockChain.Domain.Common
{
    public interface IAggregateRoot
    {
        Guid Id { get; }

        int Version { get; set; }

        void LoadDataFromHistories(IEnumerable<IEvent> eventHistories);

        IEnumerable<IEvent> GetUncommittedChanges();
    }
}
