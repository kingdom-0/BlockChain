using System;
using System.Collections.Generic;

namespace IoT.WCD.BlockChain.Domain.Queries
{
    public interface IReadOnlyDatabase<T> where T:class
    {
        T GetById(Guid id);

        void Add(T item);

        void Delete(Guid id);

        List<T> GetItems();
    }
}
