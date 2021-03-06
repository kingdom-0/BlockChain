﻿using System;
using IoT.WCD.BlockChain.Domain.Common;

namespace IoT.WCD.BlockChain.Repository.Interfaces
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot:class,IAggregateRoot
    {
        TAggregateRoot GetById(Guid id);

        void Save(IAggregateRoot aggregateRoot, int expectedVersion);
    }
}
