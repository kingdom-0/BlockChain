using System;
using System.Linq;
using IoT.WCD.BlockChain.Domain;
using IoT.WCD.BlockChain.Infrastructure.Interfaces;
using IoT.WCD.BlockChain.Repository.Interfaces;

namespace IoT.WCD.BlockChain.Repository
{
    public abstract class BaseRepository<TAggregateRoot>:IRepository<TAggregateRoot>
        where TAggregateRoot:class,IAggregateRoot
    {
        protected readonly IQueryable<TAggregateRoot> _entities;

        public BaseRepository(IDbContext dbContext)
        {
            _entities = dbContext.Set<TAggregateRoot>();
        }

        public IQueryable<TAggregateRoot> GetById(int id)
        {
            return _entities.Where(t => t.Id == id);
        }

        public IQueryable<TAggregateRoot> GetAll()
        {
            return _entities;
        }
    }
}
