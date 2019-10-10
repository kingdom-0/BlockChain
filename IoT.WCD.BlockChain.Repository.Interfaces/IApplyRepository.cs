using System.Linq;
using IoT.WCD.BlockChain.Domain;

namespace IoT.WCD.BlockChain.Repository.Interfaces
{
    public interface IApplyRepository<TApplyAggregateRoot>:IRepository<TApplyAggregateRoot>
    where TApplyAggregateRoot: class, IAggregateRoot
    {
        IQueryable<TApplyAggregateRoot> GetByUserId(int userId);
    }
}
