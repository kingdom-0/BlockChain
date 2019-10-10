using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoT.WCD.BlockChain.Domain;
using IoT.WCD.BlockChain.Infrastructure.Interfaces;
using IoT.WCD.BlockChain.Repository.Interfaces;

namespace IoT.WCD.BlockChain.Repository
{
    public class ApplyRepository<TApplyAggregateRoot>:BaseRepository<TApplyAggregateRoot>,IApplyRepository<TApplyAggregateRoot>
        where TApplyAggregateRoot:ApplyAggregateRoot
    {
        public ApplyRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<TApplyAggregateRoot> GetByUserId(int userId)
        {
            return _entities.Where(u => u.Id == userId);
        }
    }
}
