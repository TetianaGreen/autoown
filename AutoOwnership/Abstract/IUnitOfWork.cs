using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOwnership.Abstract
{
   public interface IUnitOfWork : IDisposable
    {
        IBrandRepository Brands { get; }
        ICarRepository Cars { get; }
        IOwnerRepository Owners { get; }
        IModelRepository Models { get; }
    }
}
