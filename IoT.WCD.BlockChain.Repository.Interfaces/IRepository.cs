using System.Linq;
using IoT.WCD.BlockChain.Domain;

namespace IoT.WCD.BlockChain.Repository.Interfaces
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot:class,IAggregateRoot
    {
        IQueryable<TAggregateRoot> GetById(int id);

        IQueryable<TAggregateRoot> GetAll();
    }
}
