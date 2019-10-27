using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoT.WCD.BlockChain.Application.Commands;

namespace IoT.WCD.BlockChain.Domain.DomainServices
{
    public interface IECGDataService:IDomainService<CreateECGDataCommand>
    {
    }
}
